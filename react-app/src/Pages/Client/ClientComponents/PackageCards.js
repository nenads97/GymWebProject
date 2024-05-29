import React from "react";
import { Card, CardGroup } from "react-bootstrap";
import { ReactComponent as Silver } from "../../../Icons/silver-icon.svg";
import { ReactComponent as Gold } from "../../../Icons/gold-icon.svg";
import { ReactComponent as Premium } from "../../../Icons/platinum-icon.svg";

const PackageCards = ({
  hoveredCard,
  clickedCard,
  setHoveredCard,
  setClickedCard,
  handleCardClick,
}) => {
  return (
    <div className="package-cards">
      <CardGroup>
        {(hoveredCard === "Silver" || clickedCard === "Silver") && (
          <Card
            className={`package-card${
              hoveredCard === "Silver" || clickedCard === "Silver"
                ? " hovered"
                : ""
            }`}
            onMouseEnter={() => setHoveredCard("Silver")}
            onMouseLeave={() => setHoveredCard(null)}
            onClick={() => handleCardClick("Silver")}
          >
            <Silver />
            <Card.Body>
              <Card.Title>Silver Package</Card.Title>
              <Card.Text>Price: $100</Card.Text>
              <Card.Text>Duration: 1 month</Card.Text>
              <Card.Text>Number of tokens: 10</Card.Text>
              <Card.Text>Group Sessions: 3</Card.Text>
              <Card.Text>Personal Sessions: 1</Card.Text>
              <Card.Text>Yoga & Swimming: Yes</Card.Text>
            </Card.Body>
          </Card>
        )}
        {(hoveredCard === "Gold" || clickedCard === "Gold") && (
          <Card
            className={`package-card${
              hoveredCard === "Gold" || clickedCard === "Gold" ? " hovered" : ""
            }`}
            onMouseEnter={() => setHoveredCard("Gold")}
            onMouseLeave={() => setHoveredCard(null)}
            onClick={() => handleCardClick("Gold")}
          >
            <Gold />
            <Card.Body>
              <Card.Title>Gold Package</Card.Title>
              <Card.Text>Price: $150</Card.Text>
              <Card.Text>Duration: 3 months</Card.Text>
              <Card.Text>Number of tokens: 25</Card.Text>
              <Card.Text>Group Sessions: 7</Card.Text>
              <Card.Text>Personal Sessions: 2</Card.Text>
              <Card.Text>Yoga & Swimming: Yes</Card.Text>
            </Card.Body>
          </Card>
        )}
        {(hoveredCard === "Premium" || clickedCard === "Premium") && (
          <Card
            className={`package-card${
              hoveredCard === "Premium" || clickedCard === "Premium"
                ? " hovered"
                : ""
            }`}
            onMouseEnter={() => setHoveredCard("Premium")}
            onMouseLeave={() => setHoveredCard(null)}
            onClick={() => handleCardClick("Premium")}
          >
            <Premium />
            <Card.Body>
              <Card.Title>Premium Package</Card.Title>
              <Card.Text>Price: $200</Card.Text>
              <Card.Text>Duration: 6 months</Card.Text>
              <Card.Text>Number of tokens: 50</Card.Text>
              <Card.Text>Group Sessions: 15</Card.Text>
              <Card.Text>Personal Sessions: 5</Card.Text>
              <Card.Text>Yoga & Swimming: Yes</Card.Text>
            </Card.Body>
          </Card>
        )}
      </CardGroup>
    </div>
  );
};

export default PackageCards;
