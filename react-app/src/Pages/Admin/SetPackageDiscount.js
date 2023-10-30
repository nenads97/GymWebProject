import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";

export const CreatePackage = () => {
  const [packageName, setPackageName] = useState("");

  const navigate = useNavigate();
  const { id } = useParams();

  const handleSubmit = (e) => {
    e.preventDefault(); //ovo radimo kako stranica ne bi bila relodovana cime bi izgubili useState

    var payload = {
      packageName: packageName,
      administratorId: id,
    };

    axios
      .get(`https://localhost:7095/api/Administrators/AdminGetCurrent/${id}`)
      .then((response) => {
        navigate(`/administrator/${id}`);
      });

    axios
      .post("https://localhost:7095/api/Administrators/PackageCreate", payload)
      .then((response) => {
        navigate(`/administrator/${id}`);
      })
      .catch((error) => {
        console.error("Error adding package:", error);
      });
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
