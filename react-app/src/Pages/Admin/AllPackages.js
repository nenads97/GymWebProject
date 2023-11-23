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
import DeleteConfirmation from "../../Components/DeleteConfirmation";

export const AllPackages = () => {
  const [admin, setAdmin] = useState([]);
  const [packages, setPackages] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [itemToDelete, setItemToDelete] = useState(0);

  const { id } = useParams();
  // const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/AdminGetCurrent/${id}`)
      .then((response) => {
        setAdmin(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Administrators/PackageGet`)
      .then((response) => {
        setPackages(response.data);
      });
  }, [id]);

  function showConfirmPopupHandler(packageId) {
    setShowModal(true);
    setItemToDelete(packageId);
  }

  function closeConfirmPopupHandler() {
    setShowModal(false);
    setItemToDelete(0);
  }

  function deleteConfirmHandler() {
    axios
      .delete(
        `https://localhost:7095/api/Administrators/RemovePackage/${itemToDelete}`
      )
      .then((response) => {
        // Filter out the deleted item from the existing data
        const updatedPackage = packages.filter(
          (item) => item.packageId !== itemToDelete
        );

        // Update the state with the updated data
        setPackages(updatedPackage);

        // Clear the itemToDelete and closeModal
        setItemToDelete(0);
        setShowModal(false);
      })
      .catch((error) => {
        // Handle errors if necessary
        console.error("Error deleting item:", error);
      });
  }

  return (
    <>
      <DeleteConfirmation
        showModal={showModal}
        title="Delete Confirmation!"
        body="Are you sure you want to delete this item?"
        closeConfirmPopupHandler={closeConfirmPopupHandler}
        deleteConfirmHandler={deleteConfirmHandler}
      ></DeleteConfirmation>
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
                    Prices
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
          <h2 className="clients-header headers">Packages</h2>
        </div>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
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
                    className="delete-button"
                    variant="danger"
                    type="button"
                    onClick={() => {
                      showConfirmPopupHandler(pckg.packageId);
                    }}
                  >
                    Delete
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
