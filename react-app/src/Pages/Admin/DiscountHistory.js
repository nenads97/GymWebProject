import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";
import Table from "react-bootstrap/Table";

export const DiscountHistory = () => {
  const [discounts, setDiscounts] = useState([]);

  const { id } = useParams();

  useEffect(() => {
    axios
      .get(
        `https://localhost:7095/api/Administrators/PackagePackageDiscountGet`
      )
      .then((response) => {
        // Format dates here
        const formattedDiscounts = response.data.map((discount) => ({
          ...discount,
          beginDate: formatDate(discount.beginDate),
          endDate: formatDate(discount.endDate),
        }));
        setDiscounts(formattedDiscounts);
      });
  }, [id]);

  // Function to format the date
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
        <h2 className="clients-header headers">History of Package Discounts</h2>
        <Table striped bordered hover variant="dark" className="table">
          <thead>
            <tr>
              <th>#</th>
              <th>Package Name</th>
              <th>Value</th>
              <th>Begin Date</th>
              <th>End Date</th>
            </tr>
          </thead>
          <tbody>
            {discounts.map((discount, index) => (
              <tr key={index}>
                <td>{index + 1}</td>
                <td>{discount.packageName}</td>
                <td>{discount.value}</td>
                <td>{discount.beginDate}</td>
                <td>{discount.endDate}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </div>
    </>
  );
};
