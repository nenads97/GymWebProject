import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Table from "react-bootstrap/Table";
import { Button, Alert } from "react-bootstrap";
import axios from "axios";
import TrainerHeader from "./TrainerHeader"; // Import the new header component

const TrainerPage = () => {
  const [trainer, setTrainer] = useState([]);
  const [clients, setClients] = useState([]);
  const [trainings, setTrainings] = useState([]);
  const [showAlert, setShowAlert] = useState(false);

  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/TrainerGetCurrent/${id}`)
      .then((response) => {
        setTrainer(response.data);
      });
    axios
      .get(`https://localhost:7095/api/Employees/ClientGet`)
      .then((response) => {
        setClients(response.data);
      });

    axios
      .get(
        `https://localhost:7095/api/Trainers/GetAllApplicationsForSpecificTrainer/${id}`
      )
      .then((response) => {
        setTrainings(response.data);
      });
  }, [id]);

  const formatDate = (dateString) => {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, "0");
    const month = (date.getMonth() + 1).toString().padStart(2, "0");
    const year = date.getFullYear();
    const hours = date.getHours().toString().padStart(2, "0");
    const minutes = date.getMinutes().toString().padStart(2, "0");

    return `${day}-${month}-${year} ${hours}:${minutes}`;
  };

  const handleCancelation = (trainingId) => {
    axios
      .put(
        `https://localhost:7095/api/Trainers/ChangeTrainingStatusToCanceled/${trainingId}`
      )
      .then((response) => {
        setTrainings((prevTrainings) =>
          prevTrainings.map((training) =>
            training.groupTrainingId === trainingId
              ? {
                  ...training,
                  groupTraining: { ...training.groupTraining, status: 2 },
                }
              : training
          )
        );
        setShowAlert(true);
        setTimeout(() => setShowAlert(false), 3000); // Hide the alert after 3 seconds
      })
      .catch((error) => {
        console.error("There was an error canceling the training!", error);
      });
  };

  return (
    <>
      <div className="trainer-page">
        <div className="dark-opacity">
          {showAlert && (
            <Alert
              variant="success"
              className="custom-alter"
              onClose={() => setShowAlert(false)}
              dismissible
            >
              Training successfully canceled!
            </Alert>
          )}
          <TrainerHeader trainer={trainer} id={id} />{" "}
          {/* Use the new header component */}
          <div className="header-container">
            <h2 className="clients-header headers">
              Your Applications For Trainings
            </h2>
          </div>
          <Table striped bordered hover variant="dark" className="table">
            <thead>
              <tr>
                <th>#</th>
                <th>Start Of Application</th>
                <th>Training Date And Time</th>
                <th>Number Of Spots</th>
                <th>Number Of Reserved Spots</th>
                <th>Duration</th>
                <th>Description</th>
                <th>Status</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {trainings.map((training, index) => (
                <tr key={index}>
                  <td>{index + 1}</td>
                  <td>{formatDate(training.openingDate)}</td>
                  <td>{formatDate(training.eventDate)}</td>
                  <td>{training.numberOfSpots}</td>
                  <td>{training.numberOfReservedSpots}</td>
                  <td>{training.groupTraining.duration}</td>
                  <td>{training.groupTraining.description}</td>
                  <td>
                    {training.groupTraining.status === 0 ? (
                      <span className="client-status-inactive">
                        Unavailable
                      </span>
                    ) : training.groupTraining.status === 1 ? (
                      <span className="client-status-active">Available</span>
                    ) : training.groupTraining.status === 2 ? (
                      <span className="client-status-inactive">Canceled</span>
                    ) : (
                      <span className="employee-role">Held</span>
                    )}
                  </td>
                  <td>
                    <Button
                      variant="outline-danger"
                      onClick={() =>
                        handleCancelation(training.groupTrainingId)
                      }
                    >
                      Cancel
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
          <div className="header-container">
            <h2 className="clients-header headers">Clients</h2>
          </div>
          <Table striped bordered hover variant="dark" className="table">
            <thead>
              <tr>
                <th>#</th>
                <th>Jmbg</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Gender</th>
                <th>Email</th>
                <th>Phone Number</th>
                <th>Personal Tokens</th>
                <th>Group Tokens</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              {clients.map((client, index) => (
                <tr key={index}>
                  <td>{index + 1}</td>
                  <td>{client.jmbg}</td>
                  <td>{client.firstname}</td>
                  <td>{client.surname}</td>
                  <td>{client.gender === 0 ? `Male` : `Female`}</td>
                  <td>{client.email}</td>
                  <td>{client.phoneNumber}</td>
                  <td>{client.personalTokens}</td>
                  <td>{client.groupTokens}</td>
                  <td>
                    {client.status === 0 ? (
                      <span className="client-status-inactive">Inactive</span>
                    ) : (
                      <span className="client-status-active">Active</span>
                    )}
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
      </div>
    </>
  );
};

export default TrainerPage;
