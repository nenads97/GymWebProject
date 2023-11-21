import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";

export const CreatePackageDiscount = () => {
  const [discountValue, setDiscountValue] = useState(0);
  const [beginDate, setBeginDate] = useState(
    new Date().toISOString().split("T")[0]
  );
  const [endDate, setEndDate] = useState(
    new Date().toISOString().split("T")[0]
  );
  const [errors, setErrors] = useState({});

  const navigate = useNavigate();
  const { id } = useParams();

  const [admin, setAdmin] = useState([]);

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/AdminGetCurrent/${id}`)
      .then((response) => {
        setAdmin(response.data);
      });
  }, [id]);

  const validateForm = () => {
    let valid = true;
    const newErrors = {};

    // Validate Discount Value
    if (isNaN(discountValue) || discountValue < 0 || discountValue > 100) {
      newErrors.discountValue = "Discount Value must be between 0 and 100.";
      valid = false;
    }

    // Validate Begin Date
    const currentDate = new Date().toISOString().split("T")[0];
    if (beginDate < currentDate) {
      newErrors.beginDate =
        "Begin Date must be equal to or greater than today.";
      valid = false;
    }

    // Validate End Date
    if (endDate <= beginDate) {
      newErrors.endDate = "End Date must be greater than Begin Date.";
      valid = false;
    }

    // Set errors state
    setErrors(newErrors);

    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (validateForm()) {
      var payload = {
        value: discountValue,
        beginDate: beginDate,
        endDate: endDate,
        administratorId: parseInt(id),
      };

      axios
        .post(
          "https://localhost:7095/api/Administrators/PackageDiscountCreate",
          payload
        )
        .then((response) => {
          navigate(`/administrator/${id}/all-packages`);
        })
        .catch((error) => {
          console.error("Error adding package:", error);
        });
    }
  };

  useEffect(() => {
    axios.get(
      `https://localhost:7095/api/Administrators/AdminGetCurrent/${id}`
    );
  }, [id]);

  return (
    <>
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
                <NavDropdown.Item href={`/administrator/${id}/create-package`}>
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

              <NavDropdown title="Employees" id="basic-nav-dropdown">
                <NavDropdown.Item href={`/administrator/${id}/employees`}>
                  Employees
                </NavDropdown.Item>
                <NavDropdown.Divider></NavDropdown.Divider>
                <NavDropdown.Item href={`/administrator/${id}/create-employee`}>
                  Create Employee
                </NavDropdown.Item>
              </NavDropdown>
              <NavDropdown title="Trainers" id="basic-nav-dropdown">
                <NavDropdown.Item href={`/administrator/${id}/trainers`}>
                  Trainers
                </NavDropdown.Item>
                <NavDropdown.Divider></NavDropdown.Divider>
                <NavDropdown.Item href={`/administrator/${id}/create-trainer`}>
                  Create Trainer
                </NavDropdown.Item>
              </NavDropdown>
              <Nav.Link href={`/administrator/${id}/clients`}>Clients</Nav.Link>
              <NavDropdown title="History" id="basic-nav-dropdown">
                <NavDropdown.Item href={`/administrator/${id}/price-history`}>
                  Prices
                </NavDropdown.Item>
                <NavDropdown.Item
                  href={`/administrator/${id}/discount-history`}
                >
                  Discounts
                </NavDropdown.Item>
                <NavDropdown.Item href={`/administrator/${id}/payment-history`}>
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
      <div className="package-create-page">
        <div className="auth-form-container auth-form-container-black">
          <h2 className="register-header-white">Create Package Discount</h2>
          <Form onSubmit={handleSubmit}>
            {/* Input Value */}
            <label className="form-label-white" htmlFor="discountValue">
              Input Value (%):{" "}
            </label>
            <input
              className={`register-input register-input-left ${
                errors.discountValue ? "input-error" : ""
              }`}
              type="number"
              placeholder="Discount Value"
              id="discountValue"
              name="discountValue"
              value={discountValue}
              onChange={(e) => setDiscountValue(parseFloat(e.target.value))}
            />
            {errors.discountValue && (
              <p className="error-message">{errors.discountValue}</p>
            )}

            {/* Begin Date */}
            <Form.Group className="mb-3" controlId="selectBeginDate">
              <label className="form-label-white" htmlFor="beginDate">
                Begin Date:{" "}
              </label>
              <Form.Control
                className={`register-input register-input-left ${
                  errors.beginDate ? "input-error" : ""
                }`}
                type="date"
                placeholder="Begin Date"
                id="beginDate"
                name="beginDate"
                value={beginDate}
                onChange={(e) => setBeginDate(e.target.value)}
              />
              {errors.beginDate && (
                <p className="error-message">{errors.beginDate}</p>
              )}
            </Form.Group>

            {/* End Date */}
            <Form.Group className="mb-3" controlId="selectEndDate">
              <label className="form-label-white" htmlFor="endDate">
                End Date:{" "}
              </label>
              <Form.Control
                className={`register-input register-input-left ${
                  errors.endDate ? "input-error" : ""
                }`}
                type="date"
                placeholder="End Date"
                id="endDate"
                name="endDate"
                value={endDate}
                onChange={(e) => setEndDate(e.target.value)}
              />
              {errors.endDate && (
                <p className="error-message">{errors.endDate}</p>
              )}
            </Form.Group>

            <button className="register-button">Create</button>
          </Form>
        </div>
      </div>
    </>
  );
};
