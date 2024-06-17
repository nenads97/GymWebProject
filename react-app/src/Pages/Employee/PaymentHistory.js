import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Table from "react-bootstrap/Table";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import EmployeeNavbar from "./Components/EmployeeNavbar";

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
        <EmployeeNavbar admin={employee} />

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
