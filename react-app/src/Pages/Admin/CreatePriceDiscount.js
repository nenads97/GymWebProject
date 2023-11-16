import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";

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
          navigate(`/administrator/${id}`);
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

            <button className="register-button">Submit</button>
          </Form>
        </div>
      </div>
    </>
  );
};
