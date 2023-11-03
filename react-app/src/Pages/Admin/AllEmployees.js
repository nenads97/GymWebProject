import React, { useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import axios from "axios";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import Table from "react-bootstrap/Table";
import DeleteConfirmation from "../../Components/DeleteConfirmation";
import { Button } from "react-bootstrap";

export const AllEmployees = () => {
  const [admin, setAdmin] = useState([]);
  const [clients, setClients] = useState([]);
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
      .get(`https://localhost:7095/api/Administrators/EmployeeGet`)
      .then((response) => {
        setClients(response.data);
      });
  }, [id]);

  function showConfirmPopupHandler(clientId) {
    setShowModal(true);
    setItemToDelete(clientId);
  }

  function closeConfirmPopupHandler() {
    setShowModal(false);
    setItemToDelete(0);
  }

  function deleteConfirmHandler() {
    axios
      .delete(
        `https://localhost:7095/api/Administrators/RemoveEmployee/${itemToDelete}`
      )
      .then((response) => {
        // Filter out the deleted item from the existing data
        const updateClient = clients.filter((item) => item.id !== itemToDelete);

        // Update the state with the updated data
        setClients(updateClient);

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
            <Navbar.Brand>Administrator</Navbar.Brand>
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
              </Nav>
              <Navbar.Text>
                Signed in as:{" "}
                <span className="admin_name headers">
                  {admin.firstname} {admin.surname}
                </span>
                <a href={`administrator/${id}/admin-info`}>
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    width="16"
                    height="16"
                    fill="currentColor"
                    className="user-icon"
                    viewBox="0 0 16 16"
                  >
                    <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z" />
                    <path
                      fillRule="evenodd"
                      d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z"
                    />
                  </svg>
                </a>
              </Navbar.Text>
            </Navbar.Collapse>
          </Container>
        </Navbar>

        <h2 className="clients-header headers">Employees</h2>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Jmbg</th>
              <th>First Name</th>
              <th>Last Name</th>
              <th>Username</th>
              <th>Password</th>
              <th>Gender</th>
              <th>Email</th>
              <th>Phone Number</th>
              <th>Command</th>
            </tr>
          </thead>
          <tbody>
            {clients.map((client) => (
              <tr key={client.jmbg}>
                <td>#</td>
                <td>{client.jmbg}</td>
                <td>{client.firstname}</td>
                <td>{client.surname}</td>
                <td>{client.username}</td>
                <td>{client.password}</td>
                <td>{client.gender === 0 ? `Male` : `Female`}</td>
                <td>{client.email}</td>
                <td>0{client.phoneNumber}</td>
                <td>
                  <Button
                    className="delete-button"
                    variant="danger"
                    type="button"
                    onClick={() => {
                      showConfirmPopupHandler(client.id);
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
