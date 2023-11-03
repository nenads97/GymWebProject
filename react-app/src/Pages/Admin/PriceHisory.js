import React, { useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";
import Table from "react-bootstrap/Table";

export const PriceHistory = () => {
  const [prices, setPrices] = useState([]);

  const { id } = useParams();
  // const navigate = useNavigate();

  useEffect(() => {
    axios
      .get(`https://localhost:7095/api/Administrators/PackagePriceGet`)
      .then((response) => {
        const formattedPrices = response.data.map((price) => ({
          ...price,
          date: formatDate(price.date),
        }));
        setPrices(formattedPrices);
      });
  }, [id]);

  const formatDate = (dateString) => {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, "0");
    const month = (date.getMonth() + 1).toString().padStart(2, "0");
    const year = date.getFullYear();
    const hours = date.getHours().toString().padStart(2, "0");
    const minutes = date.getMinutes().toString().padStart(2, "0");

    return `${day}-${month}-${year} ${hours}:${minutes}`;
  };

  return (
    <>
      <div className="admin-page">
        <h2 className="clients-header headers">Package Prices</h2>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Package Name</th>
              <th>Value</th>
              <th>Date Of Change</th>
            </tr>
          </thead>
          <tbody>
            {prices.map((price, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{price.packageName}</td>
                <td>{price.value}</td>
                <td>{price.date}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </>
  );
};
