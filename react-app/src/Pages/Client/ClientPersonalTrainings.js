import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import ClientInfo from "./ClientComponents/ClientInfo";
import { Table, Button, Modal, Form, Alert } from "react-bootstrap";

export const ClientPersonalTrainings = () => {
  const { id } = useParams();
  const [client, setClient] = useState({});
  const [personalTokens, setPersonalTokens] = useState(0);
  const [groupTokens, setGroupTokens] = useState(0);
  const [trainers, setTrainers] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [selectedTrainer, setSelectedTrainer] = useState(null);
  const [selectedDate, setSelectedDate] = useState("");
  const [selectedTime, setSelectedTime] = useState("");
  const [duration, setDuration] = useState("");

  const [alertMessage, setAlertMessage] = useState("");
  const [alertType, setAlertType] = useState("");
  const [showAlert, setShowAlert] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const clientResponse = await axios.get(
          `https://localhost:7095/api/Administrators/ClientGetCurrent/${id}`
        );
        setClient(clientResponse.data);

        axios
          .get(`https://localhost:7095/api/Administrators/TrainerGet`)
          .then((response) => {
            setTrainers(response.data);
          });

        const groupTokensResponse = await axios.get(
          `https://localhost:7095/api/Clients/GetClientGroupTokens/${id}`
        );
        setGroupTokens(groupTokensResponse.data.numberOfGroupTokens);

        const personalTokensResponse = await axios.get(
          `https://localhost:7095/api/Clients/GetClientPersonalTokens/${id}`
        );
        setPersonalTokens(personalTokensResponse.data.numberOfPersonalTokens);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };
    fetchData();
  }, [id]);

  const handleRequest = (trainer) => {
    setSelectedTrainer(trainer);
    setShowModal(true);
  };

  const handleSubmitRequest = () => {
    const now = new Date();
    const requestDateTime = new Date(`${selectedDate}T${selectedTime}`);

    if (requestDateTime < now) {
      setAlertMessage("The selected date and time cannot be in the past.");
      setAlertType("error");
      setShowAlert(true);
      setTimeout(() => setShowAlert(false), 3000);
      return;
    }

    if (duration < 30 || duration > 120) {
      setAlertMessage("Duration must be between 30 and 120 minutes.");
      setAlertType("error");
      setShowAlert(true);
      setTimeout(() => setShowAlert(false), 3000);
      return;
    }

    const payload = {
      clientId: parseInt(id),
      trainerId: selectedTrainer.id,
      dateAndTimeOfRequestOpening: `${selectedDate}T${selectedTime}`,
      duration: parseInt(duration),
    };

    const refreshData = async () => {
      try {
        const groupTokensResponse = await axios.get(
          `https://localhost:7095/api/Clients/GetClientGroupTokens/${id}`
        );
        setGroupTokens(groupTokensResponse.data.numberOfGroupTokens);
      } catch (error) {
        console.error("Error refreshing data:", error);
      }
    };

    axios
      .post(
        "https://localhost:7095/api/Clients/CreateWithClientRequest",
        payload
      )
      .then((response) => {
        setAlertMessage("Zahtev za personalni trening je uspesno podnet!");
        setAlertType("success");
        setShowAlert(true);
        setTimeout(() => setShowAlert(false), 3000);
        setShowModal(false); // Close the modal after successful submission
        refreshData();
      })
      .catch((error) => {
        if (error.response && error.response.data) {
          setAlertMessage(error.response.data);
          setAlertType("error");
          setShowAlert(true);
          setTimeout(() => setShowAlert(false), 3000);
        } else {
          console.error(
            "There was an error signing up for the training!",
            error
          );
        }
      });
  };

  return (
    <>
      {showAlert && (
        <Alert
          className={`custom-alert ${
            alertType === "success"
              ? "custom-alert-success"
              : "custom-alert-error"
          }`}
        >
          {alertMessage}
        </Alert>
      )}
      <ClientInfo
        id={id}
        client={client}
        personalTokens={personalTokens}
        groupTokens={groupTokens}
      />

      <div className="header-container">
        <h2 className="clients-header headers">Trainers</h2>
      </div>
      <Table striped bordered hover variant="dark" className="table">
        <thead>
          <tr>
            <th>#</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Gender</th>
            <th>Email</th>
            <th>Phone Number</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {trainers.map((trainer, index) => (
            <tr key={index}>
              <td>{index + 1}</td>
              <td>{trainer.firstname}</td>
              <td>{trainer.surname}</td>
              <td>{trainer.gender === 0 ? "Male" : "Female"}</td>
              <td>{trainer.email}</td>
              <td>0{trainer.phoneNumber}</td>
              <td>
                <Button
                  variant="success"
                  onClick={() => handleRequest(trainer)}
                >
                  Submit request
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      <Modal show={showModal} onHide={() => setShowModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>Set Date, Time, and Duration</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formDate">
              <Form.Label>Date</Form.Label>
              <Form.Control
                type="date"
                value={selectedDate}
                onChange={(e) => setSelectedDate(e.target.value)}
              />
            </Form.Group>
            <Form.Group controlId="formTime">
              <Form.Label>Time</Form.Label>
              <Form.Control
                type="time"
                value={selectedTime}
                onChange={(e) => setSelectedTime(e.target.value)}
              />
            </Form.Group>
            <Form.Group controlId="formDuration">
              <Form.Label>Duration (min)</Form.Label>
              <Form.Control
                type="number"
                min="30"
                max="120"
                value={duration}
                onChange={(e) => setDuration(e.target.value)}
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => setShowModal(false)}>
            Close
          </Button>
          <Button variant="primary" onClick={handleSubmitRequest}>
            Submit
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
