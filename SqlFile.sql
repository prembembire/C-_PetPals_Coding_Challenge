

CREATE DATABASE PetPalss;

USE PetPalss;


CREATE TABLE Pets (
    PetID INT PRIMARY KEY identity(1,1),
    Name VARCHAR(255),
    Age INT,
    Breed VARCHAR(255),
    Type VARCHAR(255),
    AvailableForAdoption BIT
);

CREATE TABLE Shelters (
    ShelterID INT PRIMARY KEY identity(1,1),
    Name VARCHAR(255),
    Location VARCHAR(255)
);

CREATE TABLE Donations (
    DonationID INT PRIMARY KEY identity(1,1),
    DonorName VARCHAR(255),
    DonationType VARCHAR(255),
    DonationAmount DECIMAL,
    DonationItem VARCHAR(255),
    DonationDate DATETIME
);

CREATE TABLE AdoptionEvents (
    EventID INT PRIMARY KEY identity(1,1),
    EventName VARCHAR(255),
    EventDate DATETIME,
    Location VARCHAR(255)
);

CREATE TABLE Participants (
    ParticipantID INT PRIMARY KEY identity(1,1),
    ParticipantName VARCHAR(255),
    ParticipantType VARCHAR(255),
    EventID INT,
    FOREIGN KEY (EventID) REFERENCES AdoptionEvents(EventID) ON delete set null
);

CREATE TABLE Adoption(
	AdoptionID INT PRIMARY KEY identity(1,1),
	PetID INT FOREIGN KEY REFERENCES Pets(PetID) on delete set null,
	UserID INT FOREIGN KEY REFERENCES Participants(ParticipantID) on delete set null
);


INSERT INTO Pets (Name, Age, Breed, Type, AvailableForAdoption) VALUES
    ('Oliver', 2, 'Labrador', 'Dog', 1),
    ('Bella', 1, 'Husky', 'Dog', 1),
    ('Milo', 3, 'Husky', 'Dog', 0),
    ('Daisy', 1, 'Pomeranian', 'Dog', 1),
    ('Rocky', 2, 'Siamese', 'Cat', 1),
    ('Luna', 4, 'German Shepherd', 'Dog', 1),
    ('Whiskers', 1, 'Dachshund', 'Dog', 0),
    ('Cleo', 2, 'Ragdoll', 'Cat', 1),
    ('Max', 1, 'Golden Retriever', 'Dog', 1),
    ( 'Nala', 3, 'Maine Coon', 'Cat', 1);


INSERT INTO Shelters (Name, Location) VALUES
    ('Zen Canine Refuge', 'Mumbai, Maharashtra'),
    ('Happy Tails Retreat', 'Delhi, Delhi'),
    ('Serenity Pups Pavilion', 'Bangalore, Karnataka'),
    ('Radiant Rescues Ranch', 'Chennai, Tamil Nadu'),
    ('Tranquil Tails Oasis', 'Kolkata, West Bengal'),
    ('Grateful Hearts Kennel', 'Hyderabad, Telangana'),
    ('Hopeful Hounds Hideaway', 'Pune, Maharashtra'),
    ('Gentle Guardian Grove', 'Ahmedabad, Gujarat'),
    ('Resilient Rover Retreat', 'Jaipur, Rajasthan'),
    ('Joyful Journeys Junction', 'Lucknow, Uttar Pradesh');


INSERT INTO Donations (DonorName, DonationType, DonationAmount, DonationItem, DonationDate) VALUES
    ('Arjun', 'Cash', 100.00, NULL, '2023-01-15 10:30:00'),
    ('Aisha', 'Item', NULL, 'Pet Food', '2023-02-02 15:45:00'),
    ('Rajat', 'Cash', 50.00, NULL, '2023-03-10 08:20:00'),
    ('Meera', 'Item', NULL, 'Pet Toys', '2023-04-05 12:10:00'),
    ('Vikram', 'Cash', 75.00, NULL, '2023-05-20 14:55:00'),
    ('Priya', 'Item', NULL, 'Pet Bed', '2023-06-18 09:30:00'),
    ('Siddharth', 'Cash', 120.00, NULL, '2023-07-03 11:40:00'),
    ('Ananya', 'Item', NULL, 'Cat Litter', '2023-08-22 16:15:00'),
    ('Rohan Gupta', 'Cash', 90.00, NULL, '2023-09-14 13:25:00'),
    ('Sanya', 'Item', NULL, 'Dog Leash', '2023-10-30 07:50:00');
	


INSERT INTO Participants (ParticipantName, ParticipantType, EventID) VALUES
    ('Vedant', 'Shelter', 1),
    ('Esha', 'Adopter', 1),
    ('Aryan', 'Shelter', 2),
    ('Riya', 'Adopter', 2),
    ('Vir', 'Shelter', 3),
    ('Kyra', 'Adopter', 3),
    ('Arnav', 'Shelter', 4),
    ('Avani', 'Adopter', 4),
    ('Reyansh', 'Shelter', 5),
    ('Meher', 'Adopter', 5);

INSERT INTO Adoption VALUES 
	( 3, 1),
	( 7, 2);

	
INSERT INTO AdoptionEvents (EventName, EventDate, Location) VALUES
    ('Pet Harmony Hour', '2023-01-25 11:00:00', 'Mumbai, Maharashtra'),
    ('Tailwaggers Unite Expo', '2023-03-15 14:30:00', 'Delhi, Delhi'),
    ('Whisker Whirlwind Showcase', '2023-05-05 12:00:00', 'Bangalore, Karnataka'),
    ('Adoption Odyssey', '2023-07-10 10:00:00', 'Chennai, Tamil Nadu'),
    ('Hearts & Paws Rendezvous', '2023-09-02 15:00:00', 'Kolkata, West Bengal'),
    ('Furever Love Fest', '2023-10-18 13:45:00', 'Hyderabad, Telangana'),
    ('Petropolis Adoption Gala', '2023-12-01 09:30:00', 'Pune, Maharashtra'),
    ('Purr-adise Found Fiesta', '2024-02-08 11:20:00', 'Ahmedabad, Gujarat'),
    ('Tails of Joy Jubilee', '2024-04-03 16:00:00', 'Jaipur, Rajasthan'),
    ('Snuggle Stray Soirée', '2024-06-22 10:45:00', 'Lucknow, Uttar Pradesh');
