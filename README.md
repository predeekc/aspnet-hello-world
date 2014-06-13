aspnet-hello-world
==================

TODO:
  - verify KVM version
  - kpm restore
  - k web

Focus on the application pipeline

Each step is tied to a progressive tag in git

Step 1: Basic Handler
  - Handler function (special case middleware)
  - Registration using Run
  - Serves basic HTML content

Step 2: Middleware
  - Build the middle ware (pre/post processing)
  - Register the middleware using a helper extension method
  - Requests now have the cache header in the response

Step 3: Using someone else's middleware
  - Register the static file handler
  - See that image now loads

Step 4: Map Middleware
  - Add map section for /private path
  - Move custom middleware into this mapped version only
  - Show that only items in the /private path have the cache response header
  