import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";

export const CreatePackage = () => {
  const [packageName, setPackageName] = useState("");
  const [packageNameError, setPackageNameError] = useState(""); // Dodato

  const navigate = useNavigate();
  const { id } = useParams();

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validacija imena paketa
    const packageNameRegex = /^[A-Z][a-zA-Z0-9]*([ ]?[a-z][a-zA-Z0-9]*)*$/;
    if (!packageNameRegex.test(packageName)) {
      setPackageNameError("Invalid package name format"); // Postavi poruku sa greškom
      return;
    } else {
      setPackageNameError(""); // Očisti poruku sa greškom ako je validno
    }

    try {
      // Provera trenutnog administratora
      await axios.get(
        `https://localhost:7095/api/Administrators/AdminGetCurrent/${id}`
      );

      // Slanje podataka za kreiranje paketa
      const payload = {
        packageName: packageName,
        administratorId: id,
      };

      await axios.post(
        "https://localhost:7095/api/Administrators/PackageCreate",
        payload
      );

      // Ako je sve uspešno, preusmeri na odgovarajuću stranicu
      navigate(`/administrator/${id}`);
    } catch (error) {
      console.error("Error adding package:", error);
    }
  };

  return (
    <>
      <div className="package-create-page">
        <div className="auth-form-container auth-form-container-black">
          <h2 className="register-header-white">Create Package</h2>

          <form className="register-form" onSubmit={handleSubmit}>
            <div className="form-group">
              <div className="input-group">
                <div>
                  <label className="form-label-white" htmlFor="packageName">
                    Package Name:{" "}
                  </label>
                  <input
                    className="register-input register-input-left"
                    type="text"
                    placeholder="Package Name"
                    id="packageName"
                    name="packageName"
                    value={packageName}
                    onChange={(e) => setPackageName(e.target.value)}
                  />
                  {packageNameError && (
                    <p className="error-message">{packageNameError}</p>
                  )}
                </div>
              </div>
            </div>
            <button className="register-button">Create</button>
          </form>
        </div>
      </div>
    </>
  );
};
