import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import { v4 as uuidv4 } from "uuid";

export const CreateGroupTraining = () => {
  const [numberOfSpots, setNumberOfSpots] = useState(0);
  const [dateAndTime, setDateAndTime] = useState(
    new Date().toISOString().slice(0, 16)
  );
  const [duration, setDuration] = useState(0); // Added for duration
  const [description, setDescription] = useState(""); // Added for description
  const [errors, setErrors] = useState({});

  const navigate = useNavigate();
  const { id } = useParams();

  const [trainer, setTrainer] = useState([]);

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/TrainerGetCurrent/${id}`)
      .then((response) => {
        setTrainer(response.data);
      });
  }, [id]);

  const validateForm = () => {
    let valid = true;
    const newErrors = {};

    // Validate Number of Spots
    if (isNaN(numberOfSpots) || numberOfSpots < 0 || numberOfSpots > 50) {
      newErrors.numberOfSpots = "Number of spots must be between 0 and 50.";
      valid = false;
    }

    // Validate Date and Time
    const currentDate = new Date().toISOString().slice(0, 16);
    if (dateAndTime < currentDate) {
      newErrors.dateAndTime =
        "Begin Date must be equal to or greater than today.";
      valid = false;
    }

    // Validate Duration
    if (isNaN(duration) || duration <= 0) {
      newErrors.duration = "Duration must be a positive number.";
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const randomId = Math.floor(10000 + Math.random() * 9000);

    if (validateForm()) {
      var payload = {
        trainingId: randomId,
        trainingType: 1,
        dateAndTime: dateAndTime,
        duration: duration, // Added duration to payload
        description: description, // Added description to payload
        trainerId: parseInt(id),
        status: 1,
      };

      var applicationPayload = {
        groupTrainingId: randomId,
        numberOfSpots: numberOfSpots,
        eventDate: dateAndTime,
        trainerId: parseInt(id),
      };

      axios
        .post(`https://localhost:7095/api/Trainers/CreateTraining`, payload)
        .then(() => {
          // First request successful, now make the second request
          return axios.post(
            `https://localhost:7095/api/Trainers/CreateApplication`,
            applicationPayload
          );
        })
        .then((response) => {
          // Second request successful
          navigate(`/trainer/${id}`);
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    }
  };

  return (
    <>
      <Navbar bg="dark" data-bs-theme="dark" className="bg-body-tertiary">
        <Container>
          <a href={`/trainer/${id}`} className="admin-link">
            <Navbar.Brand>MainPage</Navbar.Brand>
          </a>
          <Navbar.Toggle />
          <Nav className="me-auto">
            <NavDropdown title="Group Training">
              <NavDropdown.Item href={`/trainer/${id}/create-group-training`}>
                Create
              </NavDropdown.Item>
            </NavDropdown>
            <Nav.Link href={`/trainer/${id}/memberships`}>
              Membership History
            </Nav.Link>
            <Nav.Link href={`/trainer/${id}/payment-history`}>
              Payment History
            </Nav.Link>
          </Nav>
          <Navbar.Collapse className="justify-content-end">
            <Navbar.Text>
              Signed in as:{" "}
              <span className="admin_name headers">
                {trainer.firstname} {trainer.surname}
              </span>{" "}
              Role:{" "}
              <span className="admin_name headers trainer-role">Trainer</span>
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
      <div className="package-create-page">
        <div className="auth-form-container auth-form-container-black">
          <h2 className="register-header-white">Create Group Training</h2>

          <Form onSubmit={handleSubmit}>
            {/* Number of Spots */}
            <Form.Group className="mb-3" controlId="formNumberOfSpots">
              <Form.Label className="form-label-white">
                Number Of Spots:
              </Form.Label>
              <input
                className={`register-input register-input-left ${
                  errors.numberOfSpots ? "input-error" : ""
                }`}
                type="number"
                placeholder="Number Of Spots"
                id="numberOfSpots"
                name="numberOfSpots"
                min="0"
                value={numberOfSpots}
                onChange={(e) => setNumberOfSpots(e.target.value)}
              />
              {errors.numberOfSpots && (
                <p className="error-message">{errors.numberOfSpots}</p>
              )}
            </Form.Group>

            {/* Begin Date */}
            <Form.Group className="mb-3" controlId="formBeginDate">
              <label className="form-label-white" htmlFor="beginDate">
                Begin Date:{" "}
              </label>
              <Form.Control
                className={`register-input register-input-left ${
                  errors.dateAndTime ? "input-error" : ""
                }`}
                type="datetime-local"
                placeholder="Datum i vreme"
                id="beginDate"
                name="beginDate"
                value={dateAndTime}
                onChange={(e) => setDateAndTime(e.target.value)}
              />
              {errors.dateAndTime && (
                <p className="error-message">{errors.dateAndTime}</p>
              )}
            </Form.Group>

            {/* Duration */}
            <Form.Group className="mb-3" controlId="formDuration">
              <Form.Label className="form-label-white">
                Duration (minutes):
              </Form.Label>
              <input
                className={`register-input register-input-left ${
                  errors.duration ? "input-error" : ""
                }`}
                type="number"
                placeholder="Duration in minutes"
                id="duration"
                name="duration"
                min="0"
                value={duration}
                onChange={(e) => setDuration(e.target.value)}
              />
              {errors.duration && (
                <p className="error-message">{errors.duration}</p>
              )}
            </Form.Group>

            {/* Description */}
            <Form.Group className="mb-3" controlId="formDescription">
              <Form.Label className="form-label-white">Description:</Form.Label>
              <textarea
                className={`register-input register-input-left ${
                  errors.description ? "input-error" : ""
                }`}
                placeholder="Description"
                id="description"
                name="description"
                value={description}
                onChange={(e) => setDescription(e.target.value)}
              />
              {errors.description && (
                <p className="error-message">{errors.description}</p>
              )}
            </Form.Group>

            <button className="register-button">Submit</button>
          </Form>
        </div>
      </div>
    </>
  );
};
