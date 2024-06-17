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

export const GroupTrainingsPreview = () => {
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
      .get(`https://localhost:7095/api/Trainers/GetAllApplications`)
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

  return (
    <>
      <div className="employee-page">
        <EmployeeNavbar admin={admin} />

        <h2 className="client-header">Available Group Trainings</h2>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Trainer Name</th>
              <th>Start Of Application</th>
              <th>Training Date And Time</th>
              <th>Number Of Spots</th>
              <th>Number Of Reserved Spots</th>
              <th>Duration</th>
              <th>Description</th>
              <th>Status</th>
            </tr>
          </thead>
          <tbody>
            {trainings.map((training, index) => (
              <tr>
                <td>{index + 1}</td>
                <td>{training.firstname + " " + training.surname}</td>
                <td>{formatDate(training.openingDate)}</td>
                <td>{formatDate(training.eventDate)}</td>
                <td>{training.numberOfSpots}</td>
                <td>{training.numberOfReservedSpots}</td>
                <td>{training.duration}</td>
                <td>{training.description}</td>
                <td>
                  {training.trainingStatus === 0 ? (
                    <span className="client-status-inactive">Unavailable</span>
                  ) : training.trainingStatus === 1 ? (
                    <span className="client-status-active">Available</span>
                  ) : training.trainingStatus === 2 ? (
                    <span className="client-status-inactive">Canceled</span>
                  ) : (
                    <span className="employee-role">Held</span>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </>
  );
};
