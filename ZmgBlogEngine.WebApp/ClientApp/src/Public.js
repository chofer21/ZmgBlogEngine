import 'bootstrap/dist/css/bootstrap.min.css';

import { useEffect, useState } from "react"

const Public = () => {

    var userId = localStorage.getItem("userId");

    if (userId == "")
    {
        userId = 5; // public
    }

    const BaseURL = "http://localhost:5087";

    const [posts, setPosts] = useState([]);

    const loadPosts = async () => {
        const response = await fetch(BaseURL + "/public/posts");

        if (response.ok) {
            const data = await response.json();
            setPosts(data);
        }
    }

    useEffect(() => {
        loadPosts();
        console.log('posts');
        console.log(posts);
    }, [])


    const handleNewCommentClick = (postIdClicked) => {
        var commentToAdd = document.getElementById("newComment" + postIdClicked).value;

        SaveNewComment(commentToAdd, postIdClicked);
    };

    function SaveNewComment(commentToAdd, postIdClicked) {

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ content: commentToAdd, postId: postIdClicked, userId: userId })
        };
        fetch(BaseURL + '/public/comment', requestOptions)

        refreshPage();
    }

    function refreshPage() {
        window.location.reload(false);
    }

    return (
        <div className="container">
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
                                        <h5>Comments</h5>
                                        <ul className="list-group list-group-flush">
                                            {
                                                item.comments.map(
                                                    (com) => (
                                                        <div>
                                                            <li className="list-group-item">
                                                                {com.content}
                                                                <span className="opacity-50"> - By {com.user.name}</span>
                                                            </li>
                                                        </div>
                                                    )
                                                )
                                            }

                                            <div>
                                                <li className="list-group-item">

                                                    <input
                                                        type="text"
                                                        id={"newComment" + item.id}
                                                        name="newComment"
                                                    />

                                                    <button onClick={() => handleNewCommentClick(item.id)}>Add</button>


                                                </li>
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

export default Public;