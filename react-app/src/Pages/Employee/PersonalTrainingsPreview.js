import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import axios from "axios";
import NavDropdown from "react-bootstrap/NavDropdown";
import Table from "react-bootstrap/Table";
import { Button } from "react-bootstrap";
import Nav from "react-bootstrap/Nav";
import TrainingRow from "../Client/ClientComponents/TrainingRow";
import EmployeeNavbar from "./Components/EmployeeNavbar";

export const PersonalTrainingsPreview = () => {
  const [admin, setAdmin] = useState([]);
  const [clients, setClients] = useState([]);
  const [trainings, setTrainings] = useState([]);

  const { id } = useParams();
  const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/EmployeeGetCurrent/${id}`)
      .then((response) => {
        setAdmin(response.data);
      });
    axios
      .get(`https://localhost:7095/api/Employees/ClientGet`)
      .then((response) => {
        setClients(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Trainers/GetAllPersonalTrainings`)
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

  return (
    <>
      <div className="employee-page">
        <EmployeeNavbar admin={admin} />

        <h2 className="client-header">Available Personal Trainings</h2>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Trainer Full Name</th>
              <th>Client Full Name</th>
              <th>Date And Time Of Maintenance</th>
              <th>Duration</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            {trainings.map((request, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{request.trainerName}</td>
                <td>{request.clientName}</td>
                <td
                  className={
                    request.trainingStatus === 3 || request.trainingStatus === 2
                      ? "strike-through"
                      : ""
                  }
                >
                  {formatDate(request.dateAndTimeOfMaitenance)}
                </td>
                <td>{request.duration}</td>
                <td className={getStatusClassName(request.trainingStatus)}>
                  {request.trainingStatus === 0
                    ? "Pending"
                    : request.trainingStatus === 1
                    ? "Accepted"
                    : request.trainingStatus === 2
                    ? "Rejected"
                    : "Canceled"}
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </>
  );
};
