#!/usr/bin/env bash
set -euo pipefail

script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
repo_root="$(cd "${script_dir}/.." && pwd)"

rids=(
  win-x64
  win-x86
  win-arm64
  linux-x64
  linux-musl-x64
  linux-musl-arm64
  linux-arm
  linux-arm64
  linux-bionic-arm64
  linux-loongarch64
  osx-x64
  osx-arm64
  ios-arm64
  iossimulator-arm64
  iossimulator-x64
  android-arm64
  android-arm
  android-x64
  android-x86
)

output_dir="${repo_root}/published"
rm -rf "$output_dir"
mkdir -p "$output_dir"

for rid in "${rids[@]}"; do
  dest="$output_dir/$rid"
  echo "Publishing for $rid..."
  dotnet publish "${repo_root}/compiler/AtLangCompiler.csproj" -c Release -r "$rid" --self-contained -o "$dest"
done
