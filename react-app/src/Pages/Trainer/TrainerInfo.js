import React, { useState, useEffect } from "react";
//import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import axios from "axios";
import TrainerNavbar from "./Components/TrainerNavbar";

export const TrainerInfo = () => {
  const [trainer, setTrainer] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/TrainerGetCurrent/${id}`)
      .then((response) => {
        setTrainer(response.data);
      });
  }, [id]);

  return (
    <>
      <div className="trainer-page">
        <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
          <Container>
            <a href={`/trainer/${id}`} className="admin-link">
              <Navbar.Brand>MainPage</Navbar.Brand>
            </a>
            <Navbar.Toggle />
            <Nav className="me-auto">
              <NavDropdown title="Group Training">
                <NavDropdown.Item href={`/trainer/${id}/create-group-training`}>
                  Create
                </NavDropdown.Item>
              </NavDropdown>

              <NavDropdown title="Personal Training">
                <NavDropdown.Item href={`/trainer/${id}/preview-requests`}>
                  Preview requests
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
            <Navbar.Collapse className="justify-content-end">
              <Navbar.Text>
                Signed in as:{" "}
                <span className="admin_name headers">
                  {trainer.firstname} {trainer.surname}
                </span>{" "}
                Role:{" "}
                <span className="admin_name headers trainer-role">Trainer</span>
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
                <NavDropdown.Item href={`/trainer/${id}/trainer-info`}>
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
              Jmbg:{" "}
              <span className="body-row-item-employee">{trainer.jmbg}</span>
            </span>
            <span className="body-row">
              First Name:{" "}
              <span className="body-row-item-employee">
                {trainer.firstname}
              </span>
            </span>
            <span className="body-row">
              Last Name:{" "}
              <span className="body-row-item-employee">{trainer.surname}</span>
            </span>
            <span className="body-row">
              Username:{" "}
              <span className="body-row-item-employee">{trainer.username}</span>
            </span>
            <span className="body-row">
              Password:{" "}
              <span className="body-row-item-employee">{trainer.password}</span>
            </span>
            <span className="body-row">
              Gender:{" "}
              <span className="body-row-item-employee">
                {trainer.gender ? "female" : "male"}
              </span>
            </span>
            <span className="body-row">
              Email:{" "}
              <span className="body-row-item-employee">{trainer.email}</span>
            </span>
            <span className="body-row">
              Phone Number:{" "}
              <span className="body-row-item-employee">
                {trainer.phoneNumber}
              </span>
            </span>
          </div>
        </div>
      </div>
    </>
  );
};
