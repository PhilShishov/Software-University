function solve() {
  const info = document.getElementsByClassName("info")[0];
  const btnDepart = document.getElementById("depart");
  const btnArrive = document.getElementById("arrive");

  let currentId = "depot";
  const url = `https://judgetests.firebaseio.com/schedule/${currentId}.json`;

  function depart() {
    fetch(url)
      .then(resources => resources.json())
      .then(data => {
        info.textContent = `Next stop ${data.name}`;
      })
      .catch(RaiseError());

    btnDepart.disabled = true;
    btnArrive.disabled = false;
  }                                               

  function arrive() {
    fetch(url)
      .then(resources => resources.json())
      .then(data => {
        info.textContent = `Arriving at ${data.name}`;
        currentId = data.next;
      })
      .catch(RaiseError());

    btnDepart.disabled = false;
    btnArrive.disabled = true;
  }

  return {
    depart,
    arrive
  };

  function RaiseError() {
    return () => {
      info.textContent = "Error";
      departButton.disabled = true;
      arriveButton.disabled = true;
    };
  }
}

let result = solve();
