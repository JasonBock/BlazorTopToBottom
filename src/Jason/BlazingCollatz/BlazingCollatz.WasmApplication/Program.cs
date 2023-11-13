// Let's create some wasm....
using Wasmtime;

using var engine = new Engine();
using var module = Module.FromText(
	  engine,
	  "collatz-wasm",
	  """
	 (module
	   (func $collatzCallback (import "imports" "collatzCallback") (param i32))
	   (func (export "collatz") (param $0 i32) (result i32)
	     (local $1 i32)
	     (local.set $1
	       (i32.const 0)
	     )
	     (block $label$0
	       (br_if $label$0
	         (i32.lt_s
	           (local.get $0)
	           (i32.const 2)
	         )
	       )
	       (local.set $1
	         (i32.const 0)
	       )
	       (loop $label$1
	         (local.set $1
	           (i32.add
	             (local.get $1)
	             (i32.const 1)
	           )
	         )
	 		(local.get $0)
	 		(call $collatzCallback)
	         (br_if $label$1
	           (i32.gt_s
	             (local.tee $0
	               (select
	                 (i32.add
	                   (i32.mul
	                     (local.get $0)
	                     (i32.const 3)
	                   )
	                   (i32.const 1)
	                 )
	                 (i32.div_s
	                   (local.get $0)
	                   (i32.const 2)
	                 )
	                 (i32.and
	                   (local.get $0)
	                   (i32.const 1)
	                 )
	               )
	             )
	             (i32.const 1)
	           )
	         )
	       )
	     )
	     (local.get $1)
	   )
	 )
	 
	 """
);

var values = new List<int>();

using var linker = new Linker(engine);
using var store = new Store(engine);

linker.Define("imports", "collatzCallback",
	Function.FromCallback<int>(store, values.Add));

var instance = linker.Instantiate(store, module);
var run = instance.GetFunction<int, int>("collatz")!;

run(44);

Console.WriteLine(string.Join(", ", values));