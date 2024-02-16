import React, { useState, useEffect } from "react";
//import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import axios from "axios";
import Button from "react-bootstrap/Button";

export const ClientInfo = () => {
  const [client, setClient] = useState([]);
  const [groupTokens, setGroupTokens] = useState(0);
  const [personalTokens, setPersonalTokens] = useState(0);

  const { id } = useParams();

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/ClientGetCurrent/${id}`)
      .then((response) => {
        setClient(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Clients/GetClientGroupTokens/${id}`)
      .then((response) => {
        setGroupTokens(response.data.numberOfGroupTokens);
      });

    axios
      .get(`https://localhost:7095/api/Clients/GetClientPersonalTokens/${id}`)
      .then((response) => {
        setPersonalTokens(response.data.numberOfPersonalTokens);
      });
  }, [id]);

  return (
    <>
      <div className="employee-page">
        <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
          <Container>
            <a href={`/client/${id}`} className="admin-link">
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
                <span className="nav-item">
                  <span className="span1">Tokens</span>{" "}
                  <span className="span2">Balance</span>{" "}
                  <span className="span3">Status</span>{" "}
                  <span className="span4">Role</span>
                </span>
                <span className="admin_name headers">P {personalTokens}</span>
                <span className="admin_name headers">G {groupTokens}</span>
                <span className="admin_name headers">{client.balance}</span>

                <span className="admin_name headers">
                  {client.status === 0 ? (
                    <span className="client-status-inactive">Inactive</span>
                  ) : (
                    <span className="client-status-active">Active</span>
                  )}
                </span>
                <span className="admin_name headers client-role">Client</span>
              </Navbar.Text>
              <NavDropdown
                title={
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="white"
                    className="user-icon client-icon"
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
                <NavDropdown.Item href={`/client/${id}/client-info`}>
                  My Info
                </NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item href={`/`}>Log Out</NavDropdown.Item>
              </NavDropdown>
            </Navbar.Collapse>
          </Container>
        </Navbar>
        <div className="header-container">
          <h2 className="clients-header headers">Your Informations</h2>
        </div>
        <div className="body-info">
          <div className="body-container">
            <span className="body-row">
              Jmbg: <span className="body-row-item-client">{client.jmbg}</span>
            </span>
            <span className="body-row">
              First Name:{" "}
              <span className="body-row-item-client">{client.firstname}</span>
            </span>
            <span className="body-row">
              Last Name:{" "}
              <span className="body-row-item-client">{client.surname}</span>
            </span>
            <span className="body-row">
              Username:{" "}
              <span className="body-row-item-client">{client.username}</span>
            </span>
            <span className="body-row">
              Password:{" "}
              <span className="body-row-item-client">{client.password}</span>
            </span>
            <span className="body-row">
              Gender:{" "}
              <span className="body-row-item-client">
                {client.gender ? "female" : "male"}
              </span>
            </span>
            <span className="body-row">
              Email:{" "}
              <span className="body-row-item-client">{client.email}</span>
            </span>
            <span className="body-row">
              Phone Number:{" "}
              <span className="body-row-item-client">{client.phoneNumber}</span>
            </span>
            <Button
              className="change-info-button"
              variant="outline-warning"
              href={`/client/${client.id}/update-info`}
            >
              Change Info
            </Button>
          </div>
        </div>
      </div>
    </>
  );
};
