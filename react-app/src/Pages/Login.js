import axios from "axios";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

export const Login = () => {
  const [person, setPerson] = useState("");

  const [password, setPassword] = useState("");
  const [username, setUsername] = useState("");

  const [error, setError] = useState("");

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault(); //ovo radimo kako stranica ne bi bila relodovana cime bi izgubili useState

    axios
      .get(`https://localhost:7095/api/Login/${username}/${password}`)
      .then((response) => {
        setError("");
        setPerson(response.data);
        switch (person.role) {
          case 0:
            navigate(`/administrator/${response.data.id}`);
            break;
          case 1:
            navigate(`/employee/${response.data.id}`);
            break;
          case 2:
            navigate(`/client/${response.data.id}`);
            break;
          case 3:
            navigate(`/trainer/${response.data.id}`);
            break;
          default:
            navigate("/");
        }
      })
      .catch((error) => {
        setError("Pogrešan korisničko ime ili lozinka. Pokušajte ponovo."); // Postavite poruku o grešci
      });
  };

  return (
    <>
      <div className="login-page">
        <div className="login">
          <div className="auth-form-container auth-form-container-black">
            <h2 className="register-header-white">Login</h2>

            <form className="login-register-form" onSubmit={handleSubmit}>
              <div className="login-form-group">
                <div className="login-input-group">
                  <label className="login-form-label-white" htmlFor="username">
                    Username:{" "}
                  </label>
                  <input
                    className="login-register-input login-register-input-left"
                    type="text"
                    placeholder="Username"
                    id="username"
                    name="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                  />
                  <label htmlFor="password">Password: </label>
                  <input
                    className="login-register-input login-register-input-left"
                    type="password"
                    placeholder="Password"
                    id="password"
                    name="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                  />
                </div>
              </div>
              <a href={`/registration`}>Don't have an account yet? Sign Up</a>
              <button className="login-button ">Log In</button>
              {error && <p className="error-message">{error}</p>}{" "}
              {/* Prikazivanje poruke o grešci ako postoji */}
            </form>
          </div>
        </div>
      </div>
    </>
  );
};
