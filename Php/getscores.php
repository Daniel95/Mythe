<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "mythen";

$scoreType = $_GET['scoreType'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

//Read table in sql and order
//$sql = "SELECT PlayerName, Scores FROM PlayerStats ORDER BY cast(Scores as Signed) DESC";
$sql="SELECT * FROM scores ORDER BY " . scoreType . " DESC LIMIT 10";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        //echo "Name: " . $row["PlayerName"]. "\t" .$row["Scores"]. " ";
        echo "Name: " . $row["name"]. "\t" .$row[$scoreType]. " ";
    }
} else {
    echo "0 results";
}

$conn->close();
?>