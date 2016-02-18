<?php
$servername = "127.0.0.1";
$username = "regenboogslang";
$password = "mythenw8woord";
$dbname = "mythen";

$scoreType = $_POST['scoreType'];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

//Read table in sql and order
//$sql = "SELECT name, pickups FROM Scores ORDER BY cast(Scores as Signed) DESC";
$sql="SELECT * FROM Scores ORDER BY '$scoreType'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        //echo $row["id"]. "-" .$row["name"]. "-" .$row["pickups"]. "-".$row["distance"]. "-".$row["time"]."-".$row["deaths"]."t/";
        echo $row["name"]. "-" .$row[$scoreType]. "\r\n";
    }
} else {
    echo "0 results";
}

$conn->close();
?>