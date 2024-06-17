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
import EmployeeNavbar from "./Components/EmployeeNavbar"; // Import the new Navbar component

export const EmployeePage = () => {
  const [admin, setAdmin] = useState([]);
  const [clients, setClients] = useState([]);

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
  }, [id]);

  return (
    <>
      <div className="employee-page">
        <EmployeeNavbar admin={admin} />
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
              <th>Username</th>
              <th>Password</th>
              <th>Gender</th>
              <th>Email</th>
              <th>Phone Number</th>
              <th>Balance</th>
              <th>Status</th>
              <th>Commands</th>
            </tr>
          </thead>
          <tbody>
            {clients.map((client, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{client.jmbg}</td>
                <td>{client.firstname}</td>
                <td>{client.surname}</td>
                <td>{client.username}</td>
                <td>{client.password}</td>
                <td>{client.gender === 0 ? `Male` : `Female`}</td>
                <td>{client.email}</td>
                <td>{client.phoneNumber}</td>
                <td>{client.balance}</td>
                <td>
                  {client.status === 0 ? (
                    <span className="client-status-inactive">Inactive</span>
                  ) : (
                    <span className="client-status-active">Active</span>
                  )}
                </td>
                <td>
                  <Button
                    className="card-button"
                    variant="warning"
                    type="button"
                    onClick={() => {
                      navigate(
                        `/employee/${id}/update-client-balance/${client.id}`
                      );
                    }}
                  >
                    Update Balance
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </>
  );
};
