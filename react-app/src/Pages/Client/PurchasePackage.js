import React, { useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import axios from "axios";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";

export const PurchasePackage = () => {
  const [packages, setPackages] = useState([]);
  const [client, setClient] = useState([]);
  const [clientPersonalTokens, setClientPersonalTokens] = useState(0);
  const [clientGroupTokens, setClientGroupTokens] = useState(0);
  const [membership, setMembership] = useState([]);

  const { id } = useParams();

  const statusPayload = {
    status: 0,
  };
  //const navigate = useNavigate();
  //Clients/GetClientMembership/
  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/ClientGetCurrent/${id}`)
      .then((response) => {
        setClient(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Clients/GetClientMembership/${id}`)
      .then((response) => {
        setMembership(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Administrators/PackageGet`)
      .then((response) => {
        setPackages(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Clients/GetClientPersonalTokens/${id}`)
      .then((response) => {
        setClientPersonalTokens(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Clients/GetClientGroupTokens/${id}`)
      .then((response) => {
        setClientGroupTokens(response.data);
      });

    if (membership.expiryDate < new Date()) {
      axios.put(
        `https://localhost:7095/api/Clients/UpdateClientStatus/${id}`,
        statusPayload
      );
    }
  }, [id]);

  const handleSubmit = (pckg) => {
    const payload = {
      packageId: pckg.packageId,
      clientId: parseInt(id),
    };

    const payloadPersonal = {
      numberOfPersonalTokens: pckg.personalTokens,
      clientId: parseInt(id),
      personalTokenId: pckg.personalTokenId,
    };

    const payloadGroup = {
      numberOfGroupTokens: pckg.groupTokens,
      clientId: parseInt(id),
      groupTokenId: pckg.groupTokenId,
    };

    const payloadBalance = {
      balance: -pckg.packagePriceValue,
    };

    axios.post(`https://localhost:7095/api/Clients/CreateMembership`, payload);

    if (payloadPersonal.numberOfPersonalTokens !== 0) {
      axios.post(
        `https://localhost:7095/api/Clients/CreateClientPersonalToken`,
        payloadPersonal
      );
    }
    if (payloadGroup.numberOfGroupTokens !== 0) {
      axios.post(
        `https://localhost:7095/api/Clients/CreateClientGroupToken`,
        payloadGroup
      );
    }
    axios
      .put(
        `https://localhost:7095/api/Employees/UpdateClientBalance/${id}`,
        payloadBalance
      )
      .then(() => {
        window.location.reload();
      });
  };

  return (
    <>
      <div className="admin-page">
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
                Status:{" "}
                <span className="admin_name headers">
                  {client.status === 0 ? (
                    <span className="client-status-inactive">Inactive</span>
                  ) : (
                    <span className="client-status-active">Active</span>
                  )}
                </span>
                Tokens:{" "}
                <span className="admin_name headers">
                  P {clientPersonalTokens.numberOfPersonalTokens} G{" "}
                  {clientGroupTokens.numberOfGroupTokens}
                </span>
                Balance:{" "}
                <span className="admin_name headers">{client.balance}</span>
                Role:{" "}
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
          <h2 className="clients-header headers">Packages</h2>
        </div>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Personal Tokens</th>
              <th>Group Tokens</th>
              <th>Price (RSD)</th>
              <th>Discount (%)</th>
              <th>Discounted Price (RSD)</th>
              <th>Commands</th>
            </tr>
          </thead>
          <tbody>
            {packages.map((pckg, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{pckg.packageName}</td>
                <td>{pckg.personalTokens}</td>
                <td>{pckg.groupTokens}</td>
                <td>{pckg.packagePriceValue}</td>
                <td>{pckg.packageDiscountValue}</td>
                <td>
                  {pckg.packageDiscountValue === 0
                    ? pckg.packagePriceValue
                    : pckg.packagePriceValue -
                      (pckg.packagePriceValue * pckg.packageDiscountValue) /
                        100}
                </td>
                <td>
                  <Button
                    className="purchase-button"
                    variant="success"
                    type="button"
                    onClick={() => {
                      handleSubmit(pckg);
                    }}
                  >
                    Purchase
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
