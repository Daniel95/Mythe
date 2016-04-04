<?php
$servername = "127.0.0.1";
$username = "regenboogslang";
$password = "mythenw8woord";
$dbname = "mythen";

$oldName = $_POST['oldName'];
$newName = $_POST['newName'];


// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM Scores WHERE name = '$oldName'";

if($conn->query($sql)->num_rows > 0) {
    
    echo "Update Name <br>";
    
$sql2 = "UPDATE Scores 
        SET name = '$newName'
        WHERE name = '$oldName'";
   
} else {
    
    echo "TEST Make new Score with name: " . $result . "<br>" . $conn->error . "<br>";
    
    $sql2 = "INSERT INTO `$dbname`.`Scores` (name, score, pickups, distance, time, plays) VALUES ('$name', '0', '0', '0', '0', '0')";
}


if ($conn->query($sql2)) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
}

$conn->close();
?>
