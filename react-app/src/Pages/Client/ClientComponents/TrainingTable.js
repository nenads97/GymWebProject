import React from "react";
import { Table } from "react-bootstrap";
import TrainingRow from "./TrainingRow";

const TrainingTable = ({
  trainings,
  isClientSignedUp,
  handleJoin,
  handleCancel,
}) => {
  return (
    <>
      <h2 className="client-header">Available Group Trainings</h2>
      <Table striped bordered hover variant="dark" className="table">
        <thead>
          <tr>
            <th>#</th>
            <th>Trainer Name</th>
            <th>Start Of Application</th>
            <th>Training Date And Time</th>
            <th>Number Of Spots</th>
            <th>Number Of Reserved Spots</th>
            <th>Duration</th>
            <th>Description</th>
            <th>Status</th>
            <th>Signed Up</th>
            <th>Action</th>
          </tr>
        </thead>
        <tbody>
          {trainings.map((training, index) => (
            <TrainingRow
              key={index}
              index={index}
              training={training}
              isClientSignedUp={isClientSignedUp}
              handleJoin={handleJoin}
              handleCancel={handleCancel}
            />
          ))}
        </tbody>
      </Table>
    </>
  );
};

export default TrainingTable;
