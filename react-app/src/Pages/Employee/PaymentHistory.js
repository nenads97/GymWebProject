import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Table from "react-bootstrap/Table";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";

export const PaymentHistory = () => {
  const [payment, setPayments] = useState([]);

  const { id } = useParams();

  const [employee, setEmployee] = useState([]);

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/EmployeeGetCurrent/${id}`)
      .then((response) => {
        setEmployee(response.data);
      });
  }, [id]);

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Employees/GetPayments`)
      .then((response) => {
        const formattedPayments = response.data.map((payment) => ({
          ...payment,
          paymentDate: formatDate(payment.paymentDate),
        }));
        setPayments(formattedPayments);
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
                  {employee.firstname} {employee.surname}
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
          <h2 className="clients-header headers">Payment History</h2>
        </div>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>JMBG</th>
              <th>Client Name</th>
              <th>Client Surname</th>
              <th>Amount</th>
              <th>Payment Date</th>
            </tr>
          </thead>
          <tbody>
            {payment.map((payment, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{payment.clientJmbg}</td>
                <td>{payment.clientName}</td>
                <td>{payment.clientSurname}</td>
                <td>{payment.paymentAmount}</td>
                <td>{payment.paymentDate}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </>
  );
};
