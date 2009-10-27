("taijin","dwoodford","harrychou","henryc430","wmchristie","safphoto","vikasl") | foreach-object {
  git remote add $_ "git://github.com/$_/nbdn_store.git" }
