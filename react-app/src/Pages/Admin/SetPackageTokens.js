import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";

export const SetPackageTokens = () => {
  const [groupTokenAmount, setGroupTokenAmount] = useState(0);
  const [personalTokenAmount, setPersonalTokenAmount] = useState(0);
  const [packageId, setPackageId] = useState(0);
  const [packages, setPackages] = useState([]);
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

    // Validate Price Value
    if (personalTokenAmount < 0 || groupTokenAmount < 0) {
      newErrors.value = "Amount cannot be less than 0.";
      valid = false;
    }

    // Validate Package
    if (packageId === 0) {
      newErrors.packageId = "Please select a package.";
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (validateForm()) {
      var payloadPersonal = {
        quantity: personalTokenAmount,
        tokenId: 1,
        packageId: packageId,
      };

      var payloadGroup = {
        quantity: groupTokenAmount,
        tokenId: 2,
        packageId: packageId,
      };

      if (payloadPersonal.quantity > 0) {
        axios
          .post(
            "https://localhost:7095/api/Administrators/PackageTokenCreate",
            payloadPersonal
          )
          .catch((error) => {
            console.error("Error setting package price:", error);
          });
      }
      if (payloadGroup.quantity > 0) {
        axios
          .post(
            "https://localhost:7095/api/Administrators/PackageTokenCreate",
            payloadGroup
          )
          .then((response) => {
            navigate(`/administrator/${id}/all-packages`);
          })
          .catch((error) => {
            console.error("Error setting package price:", error);
          });
      }
      navigate(`/administrator/${id}/all-packages`);
    }
  };

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/PackageGet`)
      .then((response) => {
        setPackages(response.data);
      });
  }, []);

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

              <NavDropdown title="Tokens" id="basic-nav-dropdown">
                <NavDropdown.Item href={`/administrator/${id}/tokens`}>
                  Tokens
                </NavDropdown.Item>
                <NavDropdown.Item href={`/administrator/${id}/set-token-price`}>
                  Set Token Price
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
          <h2 className="register-header-white">Set Package Price</h2>

          <Form onSubmit={handleSubmit}>
            {/* Price Value */}
            <Form.Group className="mb-3" controlId="formValue">
              <Form.Label
                className="form-label-white"
                style={{ width: 120 + "px" }}
              >
                Amount of personal tokens:
              </Form.Label>
              <input
                className={`register-input register-input-left ${
                  errors.value ? "input-error" : ""
                }`}
                type="number"
                placeholder="Amount"
                id="personalToken"
                name="personalToken"
                value={personalTokenAmount}
                onChange={(e) => setPersonalTokenAmount(e.target.value)}
              />
              {errors.value && <p className="error-message">{errors.value}</p>}
            </Form.Group>

            <Form.Group className="mb-3" controlId="formValue">
              <Form.Label className="form-label-white">
                Amount of group tokens:
              </Form.Label>
              <input
                className={`register-input register-input-left ${
                  errors.value ? "input-error" : ""
                }`}
                type="number"
                placeholder="Amount"
                id="groupToken"
                name="groupToken"
                value={groupTokenAmount}
                onChange={(e) => setGroupTokenAmount(e.target.value)}
              />
              {errors.value && <p className="error-message">{errors.value}</p>}
            </Form.Group>

            {/* Select Package */}
            <Form.Group className="mb-3" controlId="formSelectPackageId">
              <label className="form-label-white" htmlFor="packageSelect">
                Select Package:{" "}
              </label>
              <Form.Select
                name="packageSelect"
                id="packageSelect"
                aria-label="Default select example"
                onChange={(event) => {
                  setPackageId(parseInt(event.target.value, 10));
                }}
                isInvalid={!!errors.packageId}
              >
                <option key="default" value="none">
                  -Select package-
                </option>
                {packages.map((pckg) => (
                  <option key={pckg.packageId} value={pckg.packageId}>
                    {pckg.packageName}
                  </option>
                ))}
              </Form.Select>
              <Form.Control.Feedback type="invalid">
                {errors.packageId}
              </Form.Control.Feedback>
            </Form.Group>

            <button className="register-button">Submit</button>
          </Form>
        </div>
      </div>
    </>
  );
};