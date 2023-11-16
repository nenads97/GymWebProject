import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";

export const SetPackagePrice = () => {
  const [value, setValue] = useState(0);
  const [packageId, setPackageId] = useState(0);
  const [packages, setPackages] = useState([]);
  const [errors, setErrors] = useState({});
  const navigate = useNavigate();
  const { id } = useParams();

  const validateForm = () => {
    let valid = true;
    const newErrors = {};

    // Validate Price Value
    if (value < 0) {
      newErrors.value = "Price value cannot be less than 0.";
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
      var payload = {
        value: value,
        administratorId: parseInt(id),
        packageId: packageId,
      };

      axios
        .post(
          "https://localhost:7095/api/Administrators/PackagePriceCreate",
          payload
        )
        .then((response) => {
          navigate(`/administrator/${id}`);
        })
        .catch((error) => {
          console.error("Error setting package price:", error);
        });
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
      <div className="package-create-page">
        <div className="auth-form-container auth-form-container-black">
          <h2 className="register-header-white">Set Package Price</h2>

          <Form onSubmit={handleSubmit}>
            {/* Price Value */}
            <Form.Group className="mb-3" controlId="formValue">
              <Form.Label className="form-label-white">Price Value:</Form.Label>
              <input
                className={`register-input register-input-left ${
                  errors.value ? "input-error" : ""
                }`}
                type="text"
                placeholder="Price Value"
                id="packageValue"
                name="packageValue"
                value={value}
                onChange={(e) => setValue(e.target.value)}
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
