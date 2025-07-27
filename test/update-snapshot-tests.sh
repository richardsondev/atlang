#!/usr/bin/env bash
set -euo pipefail

# Determine repository root relative to this script
repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"

# First run to generate updated snapshot outputs
if ! dotnet test "$repo_root/test/Tests.csproj" -c Release; then
    echo "dotnet test failed; continuing to copy snapshots" >&2
fi

# Copy generated snapshots back to source tree
for snap_dir in "$repo_root/test/bin/Release"/*/snapshots; do
    if [[ -d "$snap_dir" ]]; then
        cp "$snap_dir"/*.il "$repo_root/test/snapshots/"
    fi
done

echo "Snapshot files updated in test/snapshots."

# Second run should now succeed using the updated snapshots
dotnet test "$repo_root/test/Tests.csproj" -c Release
