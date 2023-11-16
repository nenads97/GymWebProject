import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";

export const SetPackageDiscount = () => {
  const [selectedDiscountId, setDiscountId] = useState(0);
  const [selectedPackageId, setPackageId] = useState(0);

  const [packageDiscounts, SetPackageDiscounts] = useState([]);
  const [packages, setPackages] = useState([]);
  const [errors, setErrors] = useState({});

  const navigate = useNavigate();
  const { id } = useParams();

  const validateForm = () => {
    let valid = true;
    const newErrors = {};

    // Validate Discount
    if (selectedDiscountId === 0) {
      newErrors.selectedDiscountId = "Please select a discount.";
      valid = false;
    }

    setErrors(newErrors);
    return valid;
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (validateForm()) {
      var payload = {
        packageId: selectedPackageId,
        packageDiscountId: selectedDiscountId,
        administratorId: parseInt(id),
      };

      axios
        .post(
          "https://localhost:7095/api/Administrators/PackageDiscountSet",
          payload
        )
        .then((response) => {
          navigate(`/administrator/${id}`);
        })
        .catch((error) => {
          console.error("Error setting package discount:", error);
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

    axios
      .get(`https://localhost:7095/api/Administrators/PackageDiscountGet`)
      .then((response) => {
        SetPackageDiscounts(response.data);
      });
  }, [id]);

  return (
    <>
      <div className="package-create-page">
        <div className="auth-form-container auth-form-container-black">
          <h2 className="register-header-white">Set Package Discount</h2>

          <Form onSubmit={handleSubmit}>
            {/* Select Discount */}
            <Form.Group className="mb-3" controlId="formSelectDiscountId">
              <label className="form-label-white" htmlFor="discountSelect">
                Select Discount:{" "}
              </label>
              <Form.Select
                name="discountSelect"
                id="discountSelect"
                aria-label="Default select example"
                onChange={(event) => {
                  setDiscountId(parseInt(event.target.value, 10));
                }}
                isInvalid={!!errors.selectedDiscountId}
              >
                <option key="default" value="none">
                  -Select Discount-
                </option>
                {packageDiscounts.map((discount) => (
                  <option
                    key={discount.packageDiscountId}
                    value={discount.packageDiscountId}
                  >
                    {discount.value}
                  </option>
                ))}
              </Form.Select>
              <Form.Control.Feedback type="invalid">
                {errors.selectedDiscountId}
              </Form.Control.Feedback>
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
                isInvalid={!!errors.selectedPackageId}
              >
                <option key="default" value="none">
                  -Select Package-
                </option>
                {packages.map((pckg) => (
                  <option
                    key={`package_${pckg.packageId}`}
                    value={pckg.packageId}
                  >
                    {pckg.packageName}
                  </option>
                ))}
              </Form.Select>
              <Form.Control.Feedback type="invalid">
                {errors.selectedPackageId}
              </Form.Control.Feedback>
            </Form.Group>

            <button className="register-button">Submit</button>
          </Form>
        </div>
      </div>
    </>
  );
};
