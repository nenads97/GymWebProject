import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import axios from "axios";
import NavDropdown from "react-bootstrap/NavDropdown";
import Table from "react-bootstrap/Table";
import { Button } from "react-bootstrap";
import Nav from "react-bootstrap/Nav";
import Card from "react-bootstrap/Card";
import CardGroup from "react-bootstrap/CardGroup";
import { ReactComponent as Silver } from "../../Icons/silver-icon.svg";
import { ReactComponent as Gold } from "../../Icons/gold-icon.svg";
import { ReactComponent as Premium } from "../../Icons/platinum-icon.svg";
import Modal from "react-bootstrap/Modal";

export const ClientPage = () => {
  const [client, setClient] = useState([]);
  const [groupTokens, setGroupTokens] = useState(0);
  const [personalTokens, setPersonalTokens] = useState(0);
  const [packages, setPackages] = useState([]);
  const [packageId, setPackageId] = useState(0);
  const [membership, setMembership] = useState([]);

  const [hoveredCard, setHoveredCard] = useState(null);
  const [clickedCard, setClickedCard] = useState(null);

  const [showModal, setShowModal] = useState(false);

  const navigate = useNavigate();

  var statusPayload = {
    status: 1,
  };

  const { id } = useParams();
  //const navigate = useNavigate();

  const handleCloseModal = () => {
    setShowModal(false);
  };

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
      .get(`https://localhost:7095/api/Clients/GetClientGroupTokens/${id}`)
      .then((response) => {
        setGroupTokens(response.data.numberOfGroupTokens);
      });

    axios
      .get(`https://localhost:7095/api/Clients/GetClientPersonalTokens/${id}`)
      .then((response) => {
        setPersonalTokens(response.data.numberOfPersonalTokens);
      });

    axios
      .get(`https://localhost:7095/api/Administrators/PackageGet`)
      .then((response) => {
        setPackages(response.data);
      });
    if (membership.expiryDate < new Date()) {
      axios.put(
        `https://localhost:7095/api/Clients/UpdateClientStatus/${id}`,
        statusPayload
      );
    }
  }, [id]);

  const handleCardClick = async (packageType) => {
    try {
      const element = packages.find((p) => packageType === p.packageName);

      if (element) {
        setPackageId(element.packageId);

        const payload = {
          packageId: element.packageId,
          clientId: parseInt(id),
        };

        const payloadPersonal = {
          numberOfPersonalTokens: element.groupTokens,
          personalTokenId: 1,
          clientId: parseInt(id),
        };

        const payloadGroup = {
          numberOfGroupTokens: element.groupTokens,
          groupTokenId: 2,
          clientId: parseInt(id),
        };

        const payloadPrice = {
          balance: -element.packagePriceValue,
        };

        if (client.balance >= element.packagePriceValue) {
          // Make API calls to update server data
          await axios.put(
            `https://localhost:7095/api/Employees/UpdateClientBalance/${id}`,
            payloadPrice
          );
          await axios.post(
            "https://localhost:7095/api/Clients/CreateMembership",
            payload
          );

          if (element.personalTokens > 0) {
            await axios.post(
              "https://localhost:7095/api/Clients/CreateClientPersonalToken",
              payloadPersonal
            );
          }

          if (element.groupTokens > 0) {
            await axios.post(
              "https://localhost:7095/api/Clients/CreateClientGroupToken",
              payloadGroup
            );
          }
          // Update local state variables directly
          setPersonalTokens(
            (prevTokens) => prevTokens + element.personalTokens
          );
          setGroupTokens((prevTokens) => prevTokens + element.groupTokens);
          setClient((prevClient) => ({
            ...prevClient,
            balance: prevClient.balance - element.packagePriceValue,
          }));
        } else {
          setShowModal(true);
        }
      }
    } catch (error) {
      console.error("Error processing card click:", error);
    }
  };

  return (
    <>
      <div className="employee-page">
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
              <Nav.Link href={`/employee/${id}/purchase-tokens`}>
                Purchase Tokens
              </Nav.Link>
            </Nav>
            <Navbar.Collapse className="justify-content-end">
              <Navbar.Text>
                <span className="nav-item">
                  <span className="span1">Tokens</span>{" "}
                  <span className="span2">Balance</span>{" "}
                  <span className="span3">Status</span>{" "}
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

        {client.status === 0 && (
          <h1 className="client-header">Purchase one of our packages</h1>
        )}

        {client.status === 0 && (
          <div className="package-cards">
            <CardGroup>
              {(hoveredCard === "Silver" || clickedCard === "Silver") && (
                <Card
                  className="card-purchase"
                  onMouseLeave={() => {
                    setHoveredCard(null);
                    setClickedCard(null);
                  }}
                  onClick={() => {
                    setClickedCard("Silver");
                    handleCardClick("Silver");
                  }}
                >
                  <Card.Body>
                    <p className="card-purchase-p">Click to Purchase</p>
                  </Card.Body>
                </Card>
              )}
              {hoveredCard !== "Silver" && clickedCard !== "Silver" && (
                <Card
                  onMouseEnter={() => setHoveredCard("Silver")}
                  onMouseLeave={() => {
                    setHoveredCard(null);
                    setClickedCard(null);
                  }}
                >
                  <Silver />
                  <Card.Body>
                    <Card.Title>Silver</Card.Title>
                    <Card.Text>
                      Unlock the door to fitness with our Silver package,
                      providing essential gym membership for access to. Ideal
                      for independent workouts, this package offers the
                      foundation for your fitness journey, with the option to
                      purchase personal and group training sessions separately.
                    </Card.Text>
                  </Card.Body>
                  <Card.Footer>
                    <small className="text-muted">3000 RSD</small>
                  </Card.Footer>
                </Card>
              )}
              {(hoveredCard === "Gold" || clickedCard === "Gold") && (
                <Card
                  className="card-purchase"
                  onMouseLeave={() => {
                    setHoveredCard(null);
                    setClickedCard(null);
                  }}
                  onClick={() => {
                    setClickedCard("Gold");
                    handleCardClick("Gold");
                  }}
                >
                  <Card.Body>
                    <p className="card-purchase-p">Click to Purchase</p>
                  </Card.Body>
                </Card>
              )}
              {hoveredCard !== "Gold" && clickedCard !== "Gold" && (
                <Card
                  onMouseEnter={() => setHoveredCard("Gold")}
                  onMouseLeave={() => {
                    setHoveredCard(null);
                    setClickedCard(null);
                  }}
                  onClick={() => setClickedCard("Gold")}
                >
                  <Gold />
                  <Card.Body>
                    <Card.Title>Gold</Card.Title>
                    <Card.Text>
                      Take your fitness to the next level with our Gold package,
                      which includes full gym access along with 10 group
                      training tokens. Enjoy the flexibility of personalized
                      workout plans and expert-led group sessions, giving you a
                      well-rounded fitness experience tailored to your goals.
                    </Card.Text>
                  </Card.Body>
                  <Card.Footer>
                    <small className="text-muted">4500 RSD</small>
                  </Card.Footer>
                </Card>
              )}
              {(hoveredCard === "Premium" || clickedCard === "Premium") && (
                <Card
                  className="card-purchase"
                  onMouseLeave={() => {
                    setHoveredCard(null);
                    setClickedCard(null);
                  }}
                  onClick={() => {
                    setClickedCard("Premium");
                    handleCardClick("Premium");
                  }}
                >
                  <Card.Body>
                    <p className="card-purchase-p">Click to Purchase</p>
                  </Card.Body>
                </Card>
              )}
              {hoveredCard !== "Premium" && clickedCard !== "Premium" && (
                <Card
                  onMouseEnter={() => setHoveredCard("Premium")}
                  onMouseLeave={() => {
                    setHoveredCard(null);
                    setClickedCard(null);
                  }}
                  onClick={() => setClickedCard("Premium")}
                >
                  <Premium />
                  <Card.Body>
                    <Card.Title>Premium</Card.Title>
                    <Card.Text>
                      Experience the epitome of fitness luxury with our Premium
                      package, granting unlimited gym access and 10 personal and
                      10 group training tokens. Elevate your workouts with
                      personalized attention from our expert trainers and
                      indulge in the variety of group sessions.
                    </Card.Text>
                  </Card.Body>
                  <Card.Footer>
                    <small className="text-muted">8000 RSD</small>
                  </Card.Footer>
                </Card>
              )}
            </CardGroup>
          </div>
        )}
      </div>

      <Modal show={showModal} onHide={handleCloseModal}>
        <Modal.Header closeButton>
          <Modal.Title>Insufficient Funds</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Sorry, you don't have enough funds on your account to make this
          purchase.
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCloseModal}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
};
