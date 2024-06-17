import React, { useState, useEffect } from "react";
//import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import axios from "axios";
import EmployeeNavbar from "./Components/EmployeeNavbar";

export const EmployeeInfo = () => {
  const [employee, setEmployee] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/EmployeeGetCurrent/${id}`)
      .then((response) => {
        setEmployee(response.data);
      });
  }, [id]);

  return (
    <>
      <div className="employee-page">
        <EmployeeNavbar admin={employee} />

        <div className="header-container">
          <h2 className="clients-header headers">Your Informations</h2>
        </div>
        <div className="body-info">
          <div className="body-container">
            <span className="body-row">
              Jmbg:{" "}
              <span className="body-row-item-employee">{employee.jmbg}</span>
            </span>
            <span className="body-row">
              First Name:{" "}
              <span className="body-row-item-employee">
                {employee.firstname}
              </span>
            </span>
            <span className="body-row">
              Last Name:{" "}
              <span className="body-row-item-employee">{employee.surname}</span>
            </span>
            <span className="body-row">
              Username:{" "}
              <span className="body-row-item-employee">
                {employee.username}
              </span>
            </span>
            <span className="body-row">
              Password:{" "}
              <span className="body-row-item-employee">
                {employee.password}
              </span>
            </span>
            <span className="body-row">
              Gender:{" "}
              <span className="body-row-item-employee">
                {employee.gender ? "female" : "male"}
              </span>
            </span>
            <span className="body-row">
              Email:{" "}
              <span className="body-row-item-employee">{employee.email}</span>
            </span>
            <span className="body-row">
              Phone Number:{" "}
              <span className="body-row-item-employee">
                {employee.phoneNumber}
              </span>
            </span>
          </div>
        </div>
      </div>
    </>
  );
};
