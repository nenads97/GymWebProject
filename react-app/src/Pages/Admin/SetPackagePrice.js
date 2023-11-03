import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Form from "react-bootstrap/Form";

export const SetPackagePrice = () => {
  const [value, setValue] = useState(0);
  const [packageId, setPackageId] = useState(0);

  const [packages, setPackages] = useState([]);

  const navigate = useNavigate();
  const { id } = useParams();

  const handleSubmit = (e) => {
    e.preventDefault(); //ovo radimo kako stranica ne bi bila relodovana cime bi izgubili useState

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
        console.error("Error adding package:", error);
      });
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
            <Form.Group className="mb-3" controlId="formValue">
              <Form.Label className="form-label-white">Price Value:</Form.Label>
              <input
                className="register-input register-input-left"
                type="text"
                placeholder="Price Value"
                id="packageValue"
                name="packageValue"
                value={value}
                onChange={(e) => setValue(e.target.value)}
              />
            </Form.Group>

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
            </Form.Group>

            <button className="register-button">Submit</button>
          </Form>
        </div>
      </div>
    </>
  );
};
