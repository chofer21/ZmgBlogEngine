import 'bootstrap/dist/css/bootstrap.min.css';

import { useEffect, useState } from "react"

const Writer = () => {

    var userId = localStorage.getItem("userId");
    var token = localStorage.getItem("token");
    const BaseURL = "http://localhost:5087";

    const [posts, setPosts] = useState([]);
    const [info, setInfo] = useState();

    const loadPosts = async () => {
        const response = 
            await fetch(BaseURL + "/writer/posts?writerId=" + userId,{ 
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

    const handleNewClick = () => {

        var title = document.getElementById("title").value;
        var content = document.getElementById("content").value;

        SaveNewPost(title, content);

    }

    const handleSubmitClick = (postIdClicked) => {
        Submit(postIdClicked);
    };


    function SaveNewPost(title, content) {

        const requestOptions = {
            method: 'POST',
            headers: new Headers({
                'Authorization': 'bearer '+ token,
                'Content-Type': 'application/json' 
            }),
            body: JSON.stringify({ title: title, content: content, userId: userId })
        };
        fetch(BaseURL + '/writer/post', requestOptions)

       // refreshPage();
    }

    function Submit(postIdClicked)
    {
        fetch(BaseURL + '/writer/post/submit?postId=' + postIdClicked, { 
            method: 'PUT', 
            headers: new Headers({
                'Authorization': 'bearer '+ token
            })
        })
        .catch(err => {
            console.log(err);
            setInfo("unathorized")
        });

        // refreshPage();
    }

    function refreshPage() {
        window.location.reload(false);
    }

    return (
        <div className="container">

            <div class="alert alert-info" role="alert">{info}</div>
            <h3>Add Post</h3>
            <div class="form-group">
                <label htmlFor="title">Title</label>
                <input type="text" className="form-control" id="title" placeholder="Enter title" />
            </div>
            <div class="form-group">
                <label htmlFor="content">Content</label>
                <input type="text" className="form-control" id="content" placeholder="Enter content" />
            </div>
            <div class="form-group">
                <br />
            <button onClick={() => handleNewClick()} className="btn btn-primary">Login</button>
            </div>
<hr/>
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
                                                { (item.status == "Rejected")
                                                    ? "Rejected reason:" + (item.rejectedReason)
                                                    : ""
                                                }
                                                <br/>
                                                {(item.status != "Published" && item.status != "PendingApproval")
                                                    ?  


                                                    <button onClick={() => handleSubmitClick(item.id)} className='btn btn-success'>
                                                        Submit
                                                    </button>
                                                    : ""
                                                }
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

export default Writer;