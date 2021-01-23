# RhythmsGonnaGetYou

## PEDAC

### Problem

Create a console that allows a user to store and manage the company's bands, albums, and (eventually) songs.

Notes:

- A Band can have MANY:

  - Songs
  - Albums

- An Album can have MANY:

  - Songs

- A Country can have MANY:

  - Bands

- A Style can have MANY:
  - Bands

### Examples

### Data

- Album

  - Id
  - Title
  - IsExplicit
  - ReleaseDate

- Band

  - Id
  - Name
  - CountryOfOrigin
  - NumberOfMembers
  - Website
  - Style
  - IsSigned
  - ContactName
  - ContactPhoneNumber

- Song

  - Id
  - Track Number
  - Title
  - Duration

  - Consider adding Tables for Countries and Styles

### Algorithm

Create classes for each table
Link tables together
