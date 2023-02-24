import React from 'react'
import { useState } from "react"

function Login() {

    const BaseURL = "http://localhost:5087";

    const [info, setInfo] = useState();

    const handleClick = async () => {

        var userId = document.getElementById("user").value;
        var password = document.getElementById("password").value;

        console.log(userId);


        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
        };
        const response = await fetch(BaseURL + '/login?userId=' + userId + '&password=' + password, requestOptions);
        const responseValue = await response.text();

        if (response.ok) {

            if (responseValue != "Invalid")
            {
                localStorage.setItem('token', responseValue);
                localStorage.setItem('userId', userId);
                setInfo("Ok");
            }
            else 
            {
                localStorage.setItem('token', '');
                localStorage.setItem('userId', '');
                setInfo("Invalid info");
            }
        }
    };

    return (
        <div>
            <div class="form-group">
                <label htmlFor="user">UserId</label>
                <input type="number" className="form-control" id="user" placeholder="Enter userId" />
            </div>
            <div class="form-group">
                <label htmlFor="password">Password</label>
                <input type="text" className="form-control" id="password" placeholder="Password" />
            </div>
            <div class="form-group">
                <br />
            <button onClick={() => handleClick()} className="btn btn-primary">Login</button>
            </div>

            <br/>

            <div class="alert alert-info" role="alert">{info}</div>

        </div>
    )
}

export default Login