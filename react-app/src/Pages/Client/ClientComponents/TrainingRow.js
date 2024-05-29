import React from "react";
import { Button } from "react-bootstrap";

const TrainingRow = ({
  index,
  training,
  isClientSignedUp,
  handleJoin,
  handleCancel,
}) => {
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
    <tr>
      <td>{index + 1}</td>
      <td>{training.firstname + " " + training.surname}</td>
      <td>{formatDate(training.openingDate)}</td>
      <td>{formatDate(training.eventDate)}</td>
      <td>{training.numberOfSpots}</td>
      <td>{training.numberOfReservedSpots}</td>
      <td>{training.duration}</td>
      <td>{training.description}</td>
      <td>
        {training.trainingStatus === 0 ? (
          <span className="client-status-inactive">Unavailable</span>
        ) : training.trainingStatus === 1 ? (
          <span className="client-status-active">Available</span>
        ) : training.trainingStatus === 2 ? (
          <span className="client-status-inactive">Canceled</span>
        ) : (
          <span className="employee-role">Held</span>
        )}
      </td>
      <td>
        {isClientSignedUp(training.applicationId) ? (
          <span className="client-status-active">Yes</span>
        ) : (
          <span className="client-status-inactive">No</span>
        )}
      </td>
      <td>
        {isClientSignedUp(training.applicationId) ? (
          <Button
            variant="danger"
            onClick={() => handleCancel(training.applicationId)}
          >
            Cancel
          </Button>
        ) : (
          <Button
            variant="success"
            onClick={() => handleJoin(training.applicationId)}
            disabled={training.trainingStatus !== 1}
          >
            Join
          </Button>
        )}
      </td>
    </tr>
  );
};

export default TrainingRow;
