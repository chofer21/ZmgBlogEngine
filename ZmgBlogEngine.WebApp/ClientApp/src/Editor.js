import 'bootstrap/dist/css/bootstrap.min.css';

import { useEffect, useState } from "react"

const Editor = () => {

    var userId = localStorage.getItem("userId");
    var token = localStorage.getItem("token");
    //const BaseURL = "http://localhost:5087";
    const BaseURL = "https://zmgblogengine-webapi.azurewebsites.net";

    const [posts, setPosts] = useState([]);
    const [info, setInfo] = useState();

    const loadPosts = async () => {
        const response = 
            await fetch(BaseURL + "/editor/posts",{ 
                method: 'get', 
                headers: new Headers({
                    'Authorization': 'bearer '+ token
                })
            })
            .catch(err => {
                console.log(err);
                setInfo("unathorized")
            });

        if (response.ok) {

            setInfo("Ok")
            const data = await response.json();
            setPosts(data);
        }
    }

    useEffect(() => {
        loadPosts();
        console.log('posts');
        console.log(posts);
    }, [])


    const handleApproveClick = (postIdClicked) => {
        Approve(postIdClicked);
    };

    const handleRejectClick = (postIdClicked) => {
        var reason = document.getElementById("reason" + postIdClicked).value;

        Reject(reason, postIdClicked);
    };

    function Approve(postIdClicked)
    {
        fetch(BaseURL + '/editor/approve?postId=' + postIdClicked, { 
            method: 'PUT', 
            headers: new Headers({
                'Authorization': 'bearer '+ token
            })
        })
        .catch(err => {
            console.log(err);
            setInfo("unathorized")
        })
        .finally(() =>{

            refreshPage();
        }
        );
    }

    function Reject(reason, postIdClicked) {

        const requestOptions = {
            method: 'PUT',
            headers: { 
                'Authorization': 'bearer '+ token,    
                'Content-Type': 'application/json'
             },
            body: JSON.stringify({ content: reason, id: postIdClicked, editorId: userId })
        };
        fetch(BaseURL + '/editor/reject', requestOptions)
        .finally(() =>{

            refreshPage();
        }
        );

    }

    function refreshPage() {
        window.location.reload(false);
    }

    return (
        <div className="container">

            <div class="alert alert-info" role="alert">{info}</div>

            <div className="row">
                {
                    posts.map(
                        (item) => (
                            <div className="col-md-6">
                                <div id={item.id} className="card">
                                    <div className="card-header text-bg-dark ">
                                        <span className="h3">{item.title}</span>
                                        <span className="opacity-50"> - By {item.user.name}</span>
                                    </div>
                                    <div class="card-body">
                                        <p class="card-text">{item.content}</p>
                                    </div>
                                    <div className="card-footer">
                                        <h5>Actions</h5>
                                        <ul className="list-group list-group-flush">

                                            <div>
                                                <li className="list-group-item">

                                                    <input
                                                        type="text"
                                                        id={"reason" + item.id}
                                                        name="reason"
                                                    />
                                                    <button onClick={() => handleRejectClick(item.id)} className='btn btn-danger'>
                                                        Reject
                                                    </button>
                                                </li>
                                            </div>

                                            <div>
                                                    <button onClick={() => handleApproveClick(item.id)} className='btn btn-primary'>
                                                        Approve
                                                    </button>
                                            </div>
                                        </ul>
                                    </div>
                                </div>

                                <br />
                                <br />
                            </div>
                        )
                    )
                }
            </div>
        </div>
    )

}

export default Editor;