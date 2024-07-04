import React, { useState, useEffect } from "react";
import {
  Container,
  Alert,
  Modal,
  Button,
  Card,
  CardGroup,
} from "react-bootstrap";
import ClientInfo from "./ClientComponents/ClientInfo";
import TrainingTable from "./ClientComponents/TrainingTable";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";
import { ReactComponent as Silver } from "../../Icons/silver-icon.svg";
import { ReactComponent as Gold } from "../../Icons/gold-icon.svg";
import { ReactComponent as Premium } from "../../Icons/platinum-icon.svg";

const packageIcons = {
  Silver: Silver,
  Gold: Gold,
  Premium: Premium,
};

export const ClientPage = () => {
  const [client, setClient] = useState({});
  const [groupTokens, setGroupTokens] = useState(0);
  const [personalTokens, setPersonalTokens] = useState(0);
  const [packages, setPackages] = useState([]);
  const [packageId, setPackageId] = useState(0);
  const [membership, setMembership] = useState({});
  const [hoveredCard, setHoveredCard] = useState(null);
  const [clickedCard, setClickedCard] = useState(null);
  const [trainings, setTrainings] = useState([]);
  const [signUpsGroup, setSignUpsGroup] = useState([]);
  const [showAlert, setShowAlert] = useState(false);
  const [alertMessage, setAlertMessage] = useState("");
  const [alertType, setAlertType] = useState("");
  const [showModal, setShowModal] = useState(false);
  const navigate = useNavigate();

  const statusPayload = { status: 1 };
  const { id } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const clientResponse = await axios.get(
          `https://localhost:7095/api/Administrators/ClientGetCurrent/${id}`
        );
        setClient(clientResponse.data);

        const membershipResponse = await axios.get(
          `https://localhost:7095/api/Clients/GetClientMembership/${id}`
        );
        setMembership(membershipResponse.data);

        const groupTokensResponse = await axios.get(
          `https://localhost:7095/api/Clients/GetClientGroupTokens/${id}`
        );
        setGroupTokens(groupTokensResponse.data.numberOfGroupTokens);

        const personalTokensResponse = await axios.get(
          `https://localhost:7095/api/Clients/GetClientPersonalTokens/${id}`
        );
        setPersonalTokens(personalTokensResponse.data.numberOfPersonalTokens);

        const packagesResponse = await axios.get(
          `https://localhost:7095/api/Administrators/PackageGet`
        );
        setPackages(packagesResponse.data);

        if (membershipResponse.data.expiryDate < new Date()) {
          await axios.put(
            `https://localhost:7095/api/Clients/UpdateClientStatus/${id}`,
            statusPayload
          );
        }

        const trainingsResponse = await axios.get(
          `https://localhost:7095/api/Trainers/GetAllApplications`
        );
        setTrainings(trainingsResponse.data);

        const signUpsGroupResponse = await axios.get(
          `https://localhost:7095/api/Clients/GetClientGroupTrainingSignUps/${id}`
        );
        setSignUpsGroup(signUpsGroupResponse.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      }
    };

    fetchData();
  }, [id]);

  const handleJoin = (applicationId) => {
    const payload = { clientId: parseInt(id), applicationId: applicationId };
    axios
      .post(
        `https://localhost:7095/api/Clients/SignUpForGroupTraining`,
        payload
      )
      .then((response) => {
        setAlertMessage("Successfully joined the training!");
        setAlertType("success");
        setShowAlert(true);
        setTimeout(() => setShowAlert(false), 3000);
        refreshData();
      })
      .catch((error) => {
        if (error.response && error.response.data) {
          setAlertMessage(error.response.data);
          setAlertType("error");
          setShowAlert(true);
          setTimeout(() => setShowAlert(false), 3000);
        } else {
          console.error(
            "There was an error signing up for the training!",
            error
          );
        }
      });
  };

  const handleCancel = async (applicationId) => {
    try {
      const signUp = signUpsGroup.find(
        (signUp) => signUp.applicationId === applicationId
      );
      if (signUp) {
        await axios.delete(
          `https://localhost:7095/api/Clients/SignOutForGroupTraining/${signUp.signUpId}`
        );
        setAlertMessage("Successfully cancelled the training!");
        setAlertType("success");
        setShowAlert(true);
        setTimeout(() => setShowAlert(false), 3000);
        await refreshData();
      }
    } catch (error) {
      if (error.response && error.response.data) {
        setAlertMessage(error.response.data);
        setAlertType("error");
        setShowAlert(true);
        setTimeout(() => setShowAlert(false), 3000);
      } else {
        console.error("There was an error canceling the training!", error);
      }
    }
  };

  const isClientSignedUp = (applicationId) => {
    return signUpsGroup.some(
      (signUp) => signUp.applicationId === applicationId
    );
  };

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
        const payloadPrice = { balance: -element.packagePriceValue };

        if (client.balance >= element.packagePriceValue) {
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
          setPersonalTokens(
            (prevTokens) => prevTokens + element.personalTokens
          );
          setGroupTokens((prevTokens) => prevTokens + element.groupTokens);
          setClient((prevClient) => ({
            ...prevClient,
            balance: prevClient.balance - element.packagePriceValue,
          }));
          window.location.reload();
        } else {
          setShowModal(true);
        }
      }
    } catch (error) {
      console.error("Error processing card click:", error);
    }
  };

  const refreshData = async () => {
    try {
      const signUpsGroupResponse = await axios.get(
        `https://localhost:7095/api/Clients/GetClientGroupTrainingSignUps/${id}`
      );
      setSignUpsGroup(signUpsGroupResponse.data);

      const groupTokensResponse = await axios.get(
        `https://localhost:7095/api/Clients/GetClientGroupTokens/${id}`
      );
      setGroupTokens(groupTokensResponse.data.numberOfGroupTokens);

      const trainingsResponse = await axios.get(
        `https://localhost:7095/api/Trainers/GetAllApplications`
      );
      setTrainings(trainingsResponse.data);
    } catch (error) {
      console.error("Error refreshing data:", error);
    }
  };

  return (
    <div className="client-page">
      <div className="dark-opacity">
        <Container fluid>
          {showAlert && (
            <Alert
              className={`custom-alert ${
                alertType === "success"
                  ? "custom-alert-success"
                  : "custom-alert-error"
              }`}
            >
              {alertMessage}
            </Alert>
          )}
          <ClientInfo
            id={id}
            client={client}
            personalTokens={personalTokens}
            groupTokens={groupTokens}
          />
          {client.status === 0 ? (
            <>
              <h1 className="client-header">Purchase one of our packages</h1>
              <div className="package-cards">
                <CardGroup>
                  {packages.map((pkg) => {
                    const IconComponent = packageIcons[pkg.packageName];
                    return (
                      <Card
                        key={pkg.packageId}
                        className={
                          hoveredCard === pkg.packageName ||
                          clickedCard === pkg.packageName
                            ? "card-purchase"
                            : ""
                        }
                        onMouseEnter={() => setHoveredCard(pkg.packageName)}
                        onMouseLeave={() => setHoveredCard(null)}
                        onClick={() => {
                          setClickedCard(pkg.packageName);
                          handleCardClick(pkg.packageName);
                        }}
                      >
                        {IconComponent && <IconComponent />}
                        <Card.Body>
                          <Card.Title>{pkg.packageName}</Card.Title>
                          <Card.Text>{pkg.packageDescription}</Card.Text>
                        </Card.Body>
                        <Card.Footer>
                          <small className="text-muted">
                            {pkg.packagePriceValue} RSD
                          </small>
                        </Card.Footer>
                      </Card>
                    );
                  })}
                </CardGroup>
              </div>
            </>
          ) : (
            <TrainingTable
              trainings={trainings}
              isClientSignedUp={isClientSignedUp}
              handleJoin={handleJoin}
              handleCancel={handleCancel}
            />
          )}

          <Modal show={showModal} onHide={() => setShowModal(false)}>
            <Modal.Header closeButton>
              <Modal.Title>Insufficient Funds</Modal.Title>
            </Modal.Header>
            <Modal.Body>Nemate dovoljno sredstava na računu.</Modal.Body>
            <Modal.Footer>
              <Button variant="secondary" onClick={() => setShowModal(false)}>
                Close
              </Button>
            </Modal.Footer>
          </Modal>
        </Container>
      </div>
    </div>
  );
};
