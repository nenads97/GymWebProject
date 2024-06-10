import React from "react";
import { Container, Navbar, Nav, NavDropdown } from "react-bootstrap";

const ClientInfo = ({ id, client, personalTokens, groupTokens }) => {
  return (
    <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
      <Container>
        <a href={`/client/${id}`} className="admin-link">
          <Navbar.Brand>MainPage</Navbar.Brand>
        </a>
        <Navbar.Toggle />
        <Nav className="me-auto">
          <NavDropdown title="PersonalTrainings" id="basic-nav-dropdown">
            <NavDropdown.Item href={`/client/${id}/personal-trainings`}>
              Submit requests
            </NavDropdown.Item>
            <NavDropdown.Item href={`/client/${id}/personal-training-requests`}>
              Your Requests
            </NavDropdown.Item>
          </NavDropdown>

          <Nav.Link href={`/employee/${id}/memberships`}>
            Membership History
          </Nav.Link>
          <Nav.Link href={`/employee/${id}/purchase-tokens`}>
            Purchase Tokens
          </Nav.Link>
        </Nav>
        <Navbar.Collapse className="justify-content-end">
          <Navbar.Text>
            <span className="nav-item">
              <span className="span1">Tokens</span>
              <span className="span2">Balance</span>
              <span className="span3">Status</span>
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
                fill="currentColor"
                className="bi bi-person-circle"
                viewBox="0 0 16 16"
              >
                <path d="M11 10c2.828 0 5-2.686 5-6s-2.172-6-5-6S6 1.172 6 4c0 1.567-.624 3.074-1.66 4.34C3.624 9.297 2.828 10 1 10H0c1.94 0 3.02-1.453 3.66-2.85C4.406 5.703 5 4.1 5 2c0 1.374-.29 3.244-1.88 4.34C1.98 8.297 0 10 0 10s.708-2.317.708-4.34C.708 4.062 0 3.667 0 2.667 0 1.667 1 1 2 1s2 1.048 2 2.06c0 1.016 0 1.547 0 2.547C4 7.48 4 8 5 9c0-1.374 1-3.244 1-4.34 0-.842.583-1.532 1.25-1.532C8.417 3.128 9 3.818 9 4.66 9 5.59 8.76 6.667 9.68 7.667 10.6 8.667 11 9.95 11 10z" />
                <path
                  fillRule="evenodd"
                  d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8 1a7 7 0 0 0 0 14A7 7 0 0 0 8 1zm3 7a4 4 0 1 1-8 0 4 4 0 0 1 8 0z"
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
  );
};

export default ClientInfo;
