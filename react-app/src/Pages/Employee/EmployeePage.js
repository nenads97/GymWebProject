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
        <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
          <Container>
            <a href={`/employee/${id}`} className="admin-link">
              <Navbar.Brand>MainPage</Navbar.Brand>
            </a>
            <Navbar.Toggle />
            <Nav className="me-auto">
              <Nav.Link href={`/employee/${id}/trainings`}>Trainings</Nav.Link>
              <Nav.Link href={`/employee/${id}/memberships`}>
                Membership History
              </Nav.Link>
              <Nav.Link href={`/employee/${id}/payment-history`}>
                Payment History
              </Nav.Link>
            </Nav>
            <Navbar.Collapse className="justify-content-end">
              <Navbar.Text>
                Signed in as:{" "}
                <span className="admin_name headers">
                  {admin.firstname} {admin.surname}
                </span>{" "}
                Role:{" "}
                <span className="admin_name headers employee-role">
                  Employee
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
