import 'bootstrap/dist/css/bootstrap.min.css';

import { useEffect, useState } from "react"

const App = () => {

    const [posts, setPosts] = useState([]);

    const loadPosts = async () => {
        const response = await fetch("http://localhost:5087/public/posts");

        if (response.ok)
        {
            const data = await response.json();
            setPosts(data);
        }
    }

    useEffect(() => {
        loadPosts();
        console.log('posts');
        console.log(posts);
    }, [])


    return (
        <div className="container">
            <h3 class="display-3">ZMG Blog Posts</h3>
            <br />

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
        </div>
    )

}

export default App;