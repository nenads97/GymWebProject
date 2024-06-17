import React, { useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import axios from "axios";
import Nav from "react-bootstrap/Nav";
import NavDropdown from "react-bootstrap/NavDropdown";
import Form from "react-bootstrap/Form";
import ClientInfo from "./ClientComponents/ClientInfo";

export const PurchaseTokens = () => {
  const [client, setClient] = useState([]);
  const [clientPersonalTokens, setClientPersonalTokens] = useState(0);
  const [clientGroupTokens, setClientGroupTokens] = useState(0);
  //const [membership, setMembership] = useState(0);
  const [errors, setErrors] = useState({});

  const [amountOfPersonalTokens, setAmountOfPersonalTokens] = useState(0);
  const [amountOfGroupTokens, setAmountOfGroupTokens] = useState(0);
  const [tokens, setTokens] = useState([]);

  const [totalPrice, setTotalPrice] = useState(0);

  const { id } = useParams();

  //const navigate = useNavigate();
  //Clients/GetClientMembership/

  useEffect(() => {
    // Update total price whenever the quantities of tokens change
    setTotalPrice(
      amountOfPersonalTokens * tokens[0]?.tokenPriceValue +
        amountOfGroupTokens * tokens[1]?.tokenPriceValue
    );
  }, [amountOfPersonalTokens, amountOfGroupTokens, tokens]);

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/ClientGetCurrent/${id}`)
      .then((response) => {
        setClient(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Clients/GetClientPersonalTokens/${id}`)
      .then((response) => {
        setClientPersonalTokens(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Clients/GetClientGroupTokens/${id}`)
      .then((response) => {
        setClientGroupTokens(response.data);
      });

    axios
      .get(`https://localhost:7095/api/Administrators/TokensGet`)
      .then((response) => {
        setTokens(response.data);
      });
    // if (membership.expiryDate < new Date()) {
    //   axios.put(
    //     `https://localhost:7095/api/Clients/UpdateClientStatus/${id}`,
    //     statusPayload
    //   );
    // }
  }, [id]);

  const validateForm = () => {
    let valid = true;
    const newErrors = {};

    // Validate amount of personal tokens
    if (amountOfPersonalTokens < 0) {
      newErrors.amountOfPersonalTokens =
        "Amount of personal tokens cannot be less than 0.";
      valid = false;
    }

    if (amountOfGroupTokens < 0) {
      newErrors.amountOfGroupTokens =
        "Amount of group tokens cannot be less than 0.";
      valid = false;
    }

    if (client.balance < totalPrice) {
      newErrors.insufficientFunds = "Insufficient funds in the balance.";
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    if (validateForm()) {
      const payloadPersonal = {
        numberOfPersonalTokens: amountOfPersonalTokens,
        clientId: parseInt(id),
        personalTokenId: clientPersonalTokens.personalTokenId,
      };

      const payloadGroup = {
        numberOfGroupTokens: amountOfGroupTokens,
        clientId: parseInt(id),
        groupTokenId: clientGroupTokens.groupTokenId,
      };

      const payloadBalance = {
        balance: -totalPrice,
      };

      //axios.post(`https://localhost:7095/api/Clients/CreateMembership`, payload);

      if (payloadPersonal.numberOfPersonalTokens > 0) {
        axios.post(
          `https://localhost:7095/api/Clients/CreateClientPersonalToken`,
          payloadPersonal
        );
      }
      if (payloadGroup.numberOfGroupTokens > 0) {
        axios.post(
          `https://localhost:7095/api/Clients/CreateClientGroupToken`,
          payloadGroup
        );
      }
      axios
        .put(
          `https://localhost:7095/api/Employees/UpdateClientBalance/${id}`,
          payloadBalance
        )
        .then(() => {
          window.location.reload();
        });

      setAmountOfPersonalTokens(0);
      setAmountOfGroupTokens(0);
      setErrors({});
    }
  };

  return (
    <>
      <div className="admin-page">
        <ClientInfo
          id={id}
          client={client}
          personalTokens={clientPersonalTokens.numberOfPersonalTokens}
          groupTokens={clientGroupTokens.numberOfGroupTokens}
        />
        <div className="token-price-create-page">
          <div className="auth-form-container auth-form-container-black">
            <h2 className="register-header-white">Set Token Price</h2>
            <Form onSubmit={handleSubmit}>
              {/* Price Value */}
              <Form.Group className="mb-3" controlId="formValue">
                <Form.Label
                  className="form-label-white"
                  style={{ width: 100 + "%" }}
                >
                  Amount of personal tokens:
                </Form.Label>
                <input
                  className={`register-input register-input-left ${
                    errors.amountOfPersonalTokens ? "input-error" : ""
                  }`}
                  type="number"
                  placeholder="Amount"
                  id="amountOfPersonalTokens"
                  name="amountOfPersonalTokens"
                  value={amountOfPersonalTokens}
                  onChange={(e) => setAmountOfPersonalTokens(e.target.value)}
                />
                {errors.amountOfPersonalTokens && (
                  <p className="error-message" style={{ color: "red" }}>
                    {errors.amountOfPersonalTokens}
                  </p>
                )}
              </Form.Group>

              <Form.Group className="mb-3" controlId="formValue">
                <Form.Label
                  className="form-label-white"
                  style={{ width: 100 + "%" }}
                >
                  Amount of group tokens:
                </Form.Label>
                <input
                  className={`register-input register-input-left ${
                    errors.amountOfGroupTokens ? "input-error" : ""
                  }`}
                  type="number"
                  placeholder="Amount"
                  id="amountOfGroupTokens"
                  name="amountOfGroupTokens"
                  value={amountOfGroupTokens}
                  onChange={(e) => setAmountOfGroupTokens(e.target.value)}
                />
                {errors.amountOfGroupTokens && (
                  <p className="error-message" style={{ color: "red" }}>
                    {errors.amountOfGroupTokens}
                  </p>
                )}
              </Form.Group>

              <Form.Group
                className="mb-3"
                controlId="formTotalPrice"
                style={{ textAlign: "center" }}
              >
                <Form.Label
                  className="form-label-white"
                  style={{ textAlign: "center" }}
                >
                  Total Price:
                </Form.Label>
                <p
                  className={`total-price ${
                    totalPrice < 0 ? "negative-total" : ""
                  }`}
                  style={{ color: "#66FF99" }}
                >
                  {totalPrice}
                </p>
              </Form.Group>

              {errors.insufficientFunds && (
                <p className="error-message" style={{ color: "red" }}>
                  {errors.insufficientFunds}
                </p>
              )}

              <button className="register-button" type="submit">
                Purchase
              </button>
            </Form>
          </div>
        </div>
      </div>
    </>
  );
};
