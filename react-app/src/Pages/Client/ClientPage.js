import React, { useState, useEffect } from "react";
import { Container, Row, Col, Alert } from "react-bootstrap";
import ClientInfo from "./ClientComponents/ClientInfo";
import TrainingTable from "./ClientComponents/TrainingTable";
import PackageCards from "./ClientComponents/PackageCards";
import axios from "axios";
import { useNavigate, useParams } from "react-router-dom";

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

  const handleCardClick = (packageType) => {
    setClickedCard(packageType);
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
      <Row>
        <Col>
          {client.status === 0 ? (
            <PackageCards
              hoveredCard={hoveredCard}
              clickedCard={clickedCard}
              setHoveredCard={setHoveredCard}
              setClickedCard={setClickedCard}
              handleCardClick={handleCardClick}
            />
          ) : (
            <TrainingTable
              trainings={trainings}
              isClientSignedUp={isClientSignedUp}
              handleJoin={handleJoin}
              handleCancel={handleCancel}
            />
          )}
        </Col>
      </Row>
    </Container>
  );
};
