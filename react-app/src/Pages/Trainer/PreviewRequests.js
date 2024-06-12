import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
  Container,
  Navbar,
  NavDropdown,
  Table,
  Button,
  Alert,
  Nav,
} from "react-bootstrap";
import axios from "axios";
import RequestModal from "./Components/RequestModal";

export const PreviewRequests = () => {
  const [trainer, setTrainer] = useState([]);
  const [clients, setClients] = useState([]);
  const [clientRequests, setClientRequests] = useState([]);
  const [showAlert, setShowAlert] = useState(false);
  const [alertMessage, setAlertMessage] = useState("");
  const [showModal, setShowModal] = useState(false);
  const [selectedRequest, setSelectedRequest] = useState(null);
  const [actionType, setActionType] = useState("");

  const { id } = useParams();

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
        `https://localhost:7095/api/Trainers/GetAllRequestsForSpecificTrainer/${id}`
      )
      .then((response) => {
        setClientRequests(response.data);
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

  const getStatusClassName = (status) => {
    switch (status) {
      case 0:
        return "status-pending";
      case 1:
        return "status-accepted";
      default:
        return "status-rejected";
    }
  };

  const handleAcception = (request) => {
    setSelectedRequest(request);
    setActionType("Accept");
    setShowModal(true);
  };

  const handleRejection = (request) => {
    setSelectedRequest(request);
    setActionType("Reject");
    setShowModal(true);
  };

  const handleSave = (description) => {
    const payload = {
      content: actionType === "Accept",
      requestId: selectedRequest.requestId,
      trainerId: id,
      description: description,
    };
    axios
      .post(`https://localhost:7095/api/Trainers/CreateResponse`, payload)
      .then((response) => {
        setShowAlert(true);
        setAlertMessage(`Training successfully ${actionType.toLowerCase()}ed!`);
        setTimeout(() => setShowAlert(false), 3000); // Hide the alert after 3 seconds

        // Update the status of the request in clientRequests
        setClientRequests((prevRequests) =>
          prevRequests.map((request) =>
            request.requestId === selectedRequest.requestId
              ? { ...request, requestStatus: actionType === "Accept" ? 1 : 2 }
              : request
          )
        );
      })
      .catch((error) => {
        console.error(
          `There was an error ${actionType.toLowerCase()}ing the training!`,
          error
        );
      });
    setShowModal(false);
    setSelectedRequest(null);
  };

  const handleClose = () => {
    setShowModal(false);
    setSelectedRequest(null);
  };

  return (
    <>
      <div className="trainer-page">
        <div className="dark-opacity">
          {showAlert && (
            <Alert
              variant="success"
              className="custom-alert"
              onClose={() => setShowAlert(false)}
              dismissible
            >
              {alertMessage}
            </Alert>
          )}
          <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
            <Container>
              <a href={`/trainer/${id}`} className="admin-link">
                <Navbar.Brand>MainPage</Navbar.Brand>
              </a>
              <Navbar.Toggle />
              <Nav className="me-auto">
                <NavDropdown title="Group Training">
                  <NavDropdown.Item
                    href={`/trainer/${id}/create-group-training`}
                  >
                    Create
                  </NavDropdown.Item>
                </NavDropdown>

                <NavDropdown title="Personal Training">
                  <NavDropdown.Item href={`/trainer/${id}/preview-requests`}>
                    Preview requests
                  </NavDropdown.Item>
                </NavDropdown>

                <Nav.Link href={`/trainer/${id}/memberships`}>
                  Membership History
                </Nav.Link>
                <Nav.Link href={`/trainer/${id}/payment-history`}>
                  Payment History
                </Nav.Link>
              </Nav>
              <Navbar.Collapse className="justify-content-end">
                <Navbar.Text>
                  Signed in as:{" "}
                  <span className="admin_name headers">
                    {trainer.firstname} {trainer.surname}
                  </span>{" "}
                  Role:{" "}
                  <span className="admin_name headers trainer-role">
                    Trainer
                  </span>
                </Navbar.Text>
                <NavDropdown
                  title={
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      width="16"
                      height="16"
                      fill="white"
                      className="user-icon employee-icon"
                      viewBox="0 0 16 16"
                    >
                      <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
                      <path
                        fillRule="evenodd"
                        d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z"
                      />
                    </svg>
                  }
                >
                  <NavDropdown.Item href={`/employee/${id}/employee-info`}>
                    My Info
                  </NavDropdown.Item>
                  <NavDropdown.Divider />
                  <NavDropdown.Item href={`/`}>Log Out</NavDropdown.Item>
                </NavDropdown>
              </Navbar.Collapse>
            </Container>
          </Navbar>

          <div className="header-container">
            <h2 className="clients-header headers">Client requests</h2>
          </div>

          <Table striped bordered hover variant="dark" className="table">
            <thead>
              <tr>
                <th>#</th>
                <th>Full Name</th>
                <th>Gender</th>
                <th>Email</th>
                <th>Phone Number</th>
                <th>Date And Time Of Maintenance</th>
                <th>Status</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {clientRequests.map((clientRequest, index) => (
                <tr key={index}>
                  <td>{index + 1}</td>
                  <td>{clientRequest.fullName}</td>
                  <td>{clientRequest.gender === 0 ? "Male" : "Female"}</td>
                  <td>{clientRequest.email}</td>
                  <td>{clientRequest.phoneNumber}</td>
                  <td
                    className={
                      clientRequest.requestStatus === 3 ||
                      clientRequest.requestStatus === 2
                        ? "strike-through"
                        : ""
                    }
                  >
                    {formatDate(clientRequest.dateAndTimeOfMaintenance)}
                  </td>
                  <td
                    className={getStatusClassName(clientRequest.requestStatus)}
                  >
                    {clientRequest.requestStatus === 0
                      ? "Pending"
                      : clientRequest.requestStatus === 1
                      ? "Accepted"
                      : clientRequest.requestStatus === 2
                      ? "Rejected"
                      : "Canceled"}
                  </td>
                  <td>
                    <Button
                      style={{ marginRight: "10px" }}
                      variant="outline-success"
                      disabled={clientRequest.requestStatus !== 0}
                      onClick={() => handleAcception(clientRequest)}
                    >
                      Accept
                    </Button>
                    <Button
                      variant="outline-danger"
                      disabled={clientRequest.requestStatus !== 0}
                      onClick={() => handleRejection(clientRequest)}
                    >
                      Reject
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
          <RequestModal
            show={showModal}
            handleClose={handleClose}
            handleSave={handleSave}
            actionType={actionType}
          />
        </div>
      </div>
    </>
  );
};
