// We go this from grabbing the JSON object that we are getting back from the sql lite server. Then, we turned that into a TS object so we can make a type for it. 

// This seems to almost be similar to the way that interfaces work in C#. I imagine that is why its called an interface here....

export interface Activity {
  id: string;
  title: string;
  date: string;
  description: string;
  catagory: string;
  city: string;
  venue: string;
}
