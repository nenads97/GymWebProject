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
  );
};

export default ClientInfo;
