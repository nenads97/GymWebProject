import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Table from "react-bootstrap/Table";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";

export const TokenPriceHistory = () => {
  const [prices, setPrices] = useState([]);

  const { id } = useParams();

  const [admin, setAdmin] = useState([]);

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/AdminGetCurrent/${id}`)
      .then((response) => {
        setAdmin(response.data);
      });
  }, [id]);

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/TokenPricesGet`)
      .then((response) => {
        const formattedPrices = response.data.map((price) => ({
          ...price,
          date: formatDate(price.date),
        }));
        setPrices(formattedPrices);
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
      <div className="admin-page">
        <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
          <Container>
            <a href={`/administrator/${id}`} className="admin-link">
              <Navbar.Brand>MainPage</Navbar.Brand>
            </a>
            <Navbar.Toggle />
            <Navbar.Collapse className="justify-content-end">
              <Nav className="me-auto">
                <NavDropdown title="Packages" id="basic-nav-dropdown">
                  <NavDropdown.Item href={`/administrator/${id}/all-packages`}>
                    Packages
                  </NavDropdown.Item>
                  <NavDropdown.Divider></NavDropdown.Divider>
                  <NavDropdown.Item
                    href={`/administrator/${id}/create-package`}
                  >
                    Create Package
                  </NavDropdown.Item>
                  <NavDropdown.Item
                    href={`/administrator/${id}/create-package-discount`}
                  >
                    Create Package Discount
                  </NavDropdown.Item>
                  <NavDropdown.Item
                    href={`/administrator/${id}/set-package-discount`}
                  >
                    Set Package Discount
                  </NavDropdown.Item>
                  <NavDropdown.Item
                    href={`/administrator/${id}/set-package-price`}
                  >
                    Set Package Price
                  </NavDropdown.Item>
                </NavDropdown>

                <NavDropdown title="Tokens" id="basic-nav-dropdown">
                  <NavDropdown.Item href={`/administrator/${id}/tokens`}>
                    Tokens
                  </NavDropdown.Item>
                  <NavDropdown.Item
                    href={`/administrator/${id}/set-token-price`}
                  >
                    Set Token Price
                  </NavDropdown.Item>
                </NavDropdown>

                <NavDropdown title="Employees" id="basic-nav-dropdown">
                  <NavDropdown.Item href={`/administrator/${id}/employees`}>
                    Employees
                  </NavDropdown.Item>
                  <NavDropdown.Divider></NavDropdown.Divider>
                  <NavDropdown.Item
                    href={`/administrator/${id}/create-employee`}
                  >
                    Create Employee
                  </NavDropdown.Item>
                </NavDropdown>
                <NavDropdown title="Trainers" id="basic-nav-dropdown">
                  <NavDropdown.Item href={`/administrator/${id}/trainers`}>
                    Trainers
                  </NavDropdown.Item>
                  <NavDropdown.Divider></NavDropdown.Divider>
                  <NavDropdown.Item
                    href={`/administrator/${id}/create-trainer`}
                  >
                    Create Trainer
                  </NavDropdown.Item>
                </NavDropdown>
                <Nav.Link href={`/administrator/${id}/clients`}>
                  Clients
                </Nav.Link>
                <NavDropdown title="History" id="basic-nav-dropdown">
                  <NavDropdown.Item href={`/administrator/${id}/price-history`}>
                    Package Prices
                  </NavDropdown.Item>
                  <NavDropdown.Item
                    href={`/administrator/${id}/token-price-history`}
                  >
                    Token Prices
                  </NavDropdown.Item>
                  <NavDropdown.Item
                    href={`/administrator/${id}/discount-history`}
                  >
                    Discounts
                  </NavDropdown.Item>
                  <NavDropdown.Item
                    href={`/administrator/${id}/payment-history`}
                  >
                    Client Payments
                  </NavDropdown.Item>
                </NavDropdown>
              </Nav>
              <Navbar.Text>
                Signed in as:{" "}
                <span className="admin_name headers">
                  {admin.firstname} {admin.surname}
                </span>{" "}
                Role:{" "}
                <span className="admin_name headers admin-role">
                  Administrator
                </span>
              </Navbar.Text>
              <NavDropdown
                title={
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="white"
                    className="user-icon"
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
                <NavDropdown.Item href={`/administrator/${id}/admin-info`}>
                  My Info
                </NavDropdown.Item>
                <NavDropdown.Divider />
                <NavDropdown.Item href={`/`}>Log Out</NavDropdown.Item>
              </NavDropdown>
            </Navbar.Collapse>
          </Container>
        </Navbar>
        <div className="header-container">
          <h2 className="clients-header headers">Token Prices</h2>
        </div>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Token Type</th>
              <th>Value</th>
              <th>Date Of Creation</th>
            </tr>
          </thead>
          <tbody>
            {prices.map((price, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{price.tokenType === 0 ? "Personal" : "Group"}</td>
                <td>{price.value}</td>
                <td>{price.date}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </>
  );
};
