function Authorize() {
    var email = document.getElementById("inputEmail");
    var password = document.getElementById("inputPassword");

    var req = {
        "addressEmail": "user1@example.com",
        "password": "stringQ123!",
        "rememberMe": true
      };

    // $.getJSON( "https://localhost:7000/Item/getall",
    // function( data ) {
    // alert("po");
    // alert(JSON.stringify(data));
    // });

    const requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(req),
    };


    fetch('https://localhost:7000/Item/getall')
    .then(response => response.json())
    .then(data => console.log(data));

    // fetch('https://localhost:7000/Item/getall', requestOptions)
    // .then(response => response.json())
    // .then(data => alert(data));
}