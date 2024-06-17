import React from "react";
import { useNavigate, useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import Nav from "react-bootstrap/Nav";

const EmployeeNavbar = ({ admin }) => {
  const { id } = useParams();
  const navigate = useNavigate();

  return (
    <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
      <Container>
        <a href={`/employee/${id}`} className="admin-link">
          <Navbar.Brand>MainPage</Navbar.Brand>
        </a>
        <Navbar.Toggle />
        <Nav className="me-auto">
          <Nav.Link href={`/employee/${id}/all-group-trainings`}>
            Group Trainings
          </Nav.Link>
          <Nav.Link href={`/employee/${id}/all-personal-trainings`}>
            Personal Trainings
          </Nav.Link>
          <Nav.Link href={`/employee/${id}/payment-history`}>
            PaymentHistory
          </Nav.Link>
        </Nav>
        <Navbar.Collapse className="justify-content-end">
          <Navbar.Text>
            Signed in as:{" "}
            <span className="admin_name headers">
              {admin.firstname} {admin.surname}
            </span>{" "}
            Role:{" "}
            <span className="admin_name headers employee-role">Employee</span>
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
  );
};

export default EmployeeNavbar;
