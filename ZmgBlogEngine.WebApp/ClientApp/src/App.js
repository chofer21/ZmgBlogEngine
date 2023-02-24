import { Routes, Route } from "react-router-dom"
import Public from "./Public"
import Writer from "./Writer"
import Editor from "./Editor"
import Login from "./Login"


function App() {

  return (
    <div className="App">
    <div className="container">
        <h3 class="display-3">ZMG Blog Posts</h3>
        <br />
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="/">Public</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="/login">Login</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="/writer">Writer</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="/editor">Editor</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Link</a>
        </li>
      </ul>
    </div>
  </div>
</nav>
<br/>

      <Routes>
        <Route path="/" element={ <Public/> } />
        <Route path="login" element={ <Login/> } />
        <Route path="writer" element={ <Writer/> } />
        <Route path="editor" element={ <Editor/> } />
      </Routes>
    </div>
    </div>
  )
}

export default App