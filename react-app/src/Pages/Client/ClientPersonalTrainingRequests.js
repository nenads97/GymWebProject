import React, { useState, useEffect } from "react";
import { Table, Button, Alert } from "react-bootstrap";
import { useParams } from "react-router-dom";
import axios from "axios";
import ClientInfo from "./ClientComponents/ClientInfo";

export const ClientPersonalTrainingRequests = () => {
  const { id } = useParams();
  const [client, setClient] = useState({});
  const [personalTokens, setPersonalTokens] = useState(0);
  const [groupTokens, setGroupTokens] = useState(0);
  const [requests, setRequests] = useState([]);
  const [showAlert, setShowAlert] = useState(false);
  const [alertMessage, setAlertMessage] = useState("");
  const [alertType, setAlertType] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      try {
        const clientResponse = await axios.get(
          `https://localhost:7095/api/Administrators/ClientGetCurrent/${id}`
        );
        setClient(clientResponse.data);

        const requestResponse = await axios.get(
          `https://localhost:7095/api/Clients/GetClientPersonalTrainingRequests/${id}`
        );
        setRequests(requestResponse.data);

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

  const handleRequest = (request) => {
    let requestId = request.Request.RequestId;
    let status = 3;

    axios
      .put(
        `https://localhost:7095/api/Clients/UpdateClientRequestStatus`,
        null,
        {
          params: {
            id: requestId,
            status: status,
          },
        }
      )
      .then((response) => {
        setRequests((prevRequests) =>
          prevRequests.map((req) =>
            req.Request.RequestId === requestId
              ? { ...req, Request: { ...req.Request, Status: status } }
              : req
          )
        );
        setAlertMessage("Training successfully canceled!");
        setAlertType("success");
        setShowAlert(true);
        setTimeout(() => setShowAlert(false), 3000); // Clear message after 3 seconds
      })
      .catch((error) => {
        setAlertMessage("There was an error updating the request status!");
        setAlertType("error");
        setShowAlert(true);
        setTimeout(() => setShowAlert(false), 3000);
        console.error("There was an error updating the request status!", error);
      });
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

  const formatDate = (dateString) => {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, "0");
    const month = (date.getMonth() + 1).toString().padStart(2, "0");
    const year = date.getFullYear();
    const hours = date.getHours().toString().padStart(2, "0");
    const minutes = date.getMinutes().toString().padStart(2, "0");

    return `${day}-${month}-${year} ${hours}:${minutes}`;
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
        <h2 className="clients-header headers">Personal Training Requests</h2>
      </div>
      <Table striped bordered hover variant="dark" className="table">
        <thead>
          <tr>
            <th>#</th>
            <th>Trainer Full Name</th>
            <th>Gender</th>
            <th>Email</th>
            <th>Phone Number</th>
            <th>Date And Time Of Maintenance</th>
            <th>Duration</th>
            <th>Trainer's Response Message</th>
            <th>Status</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {requests.map((request, index) => (
            <tr key={index}>
              <td>{index + 1}</td>
              <td>
                {request.Trainer.Firstname + " " + request.Trainer.Surname}
              </td>
              <td>{request.Trainer.Gender === 0 ? "Male" : "Female"}</td>
              <td>{request.Trainer.Email}</td>
              <td>{request.Trainer.PhoneNumber}</td>
              <td
                className={
                  request.Request.Status === 3 || request.Request.Status === 2
                    ? "strike-through"
                    : ""
                }
              >
                {formatDate(request.Request.DateAndTimeOfRequestOpening)}
              </td>
              <td>{request.Request.Duration}</td>
              <td>{request.Request.PersonalTraining?.Description}</td>
              <td className={getStatusClassName(request.Request.Status)}>
                {request.Request.Status === 0
                  ? "Pending"
                  : request.Request.Status === 1
                  ? "Accepted"
                  : request.Request.Status === 2
                  ? "Rejected"
                  : "Canceled"}
              </td>
              <td>
                <Button
                  variant="danger"
                  onClick={() => handleRequest(request)}
                  disabled={request.Request.Status === 3}
                >
                  Cancel
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
};
